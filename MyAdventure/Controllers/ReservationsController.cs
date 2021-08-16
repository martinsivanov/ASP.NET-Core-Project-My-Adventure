namespace MyAdventure.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Data;
    using MyAdventure.Infrastructure;
    using MyAdventure.Models.Reservations;
    using MyAdventure.Services.Guides;
    using MyAdventure.Services.Reservations;
    using MyAdventure.Services.Routes;

    using static Data.DataConstants.Error;

    public class ReservationsController : Controller
    {
        private readonly IReservationService reservationService;
        private readonly MyAdventureDbContext data;
        private readonly IRouteService routeService;
        private readonly IGuideService guideService;

        public ReservationsController(IReservationService reservationService, MyAdventureDbContext data, IRouteService routeService, IGuideService guideService)
        {
            this.reservationService = reservationService;
            this.data = data;
            this.routeService = routeService;
            this.guideService = guideService;
        }

        [Authorize]
        public IActionResult Add(int id)
        {
            var route = this.routeService.GetDetails(id);
            var reservationForm = new ReservationFormModel
            {
                RouteName = route.Name
            };

            return View(reservationForm);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(int id, ReservationFormModel reservationForm)
        {
            var userId = this.User.GetId();
            var route = this.routeService.GetDetails(id);

            if (this.guideService.IsGuide(userId))
            {
                this.ModelState.AddModelError(nameof(reservationForm.GuideId), UserIsGuide);
            }

            if (this.reservationService.CheckIfUserExistsInRoute(userId, route.Id))
            {
                this.ModelState.AddModelError(nameof(reservationForm.RouteId), UserExist);
            }
            if (this.ModelState.IsValid)
            {
                var isCreated = this.reservationService.AddReservation
                (
                route.Id,
                route.GuideId,
                userId,
                reservationForm.FistName,
                reservationForm.LastName,
                reservationForm.City,
                reservationForm.PhoneNumber
                );
                if (!isCreated)
                {
                    this.ModelState.AddModelError(nameof(reservationForm.RouteName), RouteFull);
                }
            }
            if (!this.ModelState.IsValid)
            {
                return this.View(reservationForm);
            }
            return this.RedirectToAction(nameof(UserReservations));
        }

        public IActionResult UserReservations()
        {
            var reservations = this.reservationService.GetMyReservationsByUser(this.User.GetId());

            return this.View(reservations);
        }

        [Authorize]
        public IActionResult Cancel(int id)
        {
            this.reservationService.Cancel(id);

            return RedirectToAction(nameof(UserReservations));
        }

        [Authorize]
        public IActionResult Remove(int id)
        {
            var GuideCanRemove = this.guideService.CanGuideRemoveReservation(this.User.GetId(),id);
            if (GuideCanRemove)
            {
                this.reservationService.Cancel(id);
            }
            else
            {
                return BadRequest();
            }
            return this.RedirectToAction("AllParticipants", "Guides");
        }
    }
}
