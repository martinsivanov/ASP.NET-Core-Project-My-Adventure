namespace MyAdventure.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Infrastructure;
    using MyAdventure.Models.Reservations;
    using MyAdventure.Services.Guides;
    using MyAdventure.Services.Reservations;
    using MyAdventure.Services.Routes;

    using static Data.DataConstants.Error;

    public class ReservationsController : Controller
    {
        private readonly IReservationService reservationService;
        private readonly IRouteService routeService;
        private readonly IGuideService guideService;

        public ReservationsController(IReservationService reservationService, IRouteService routeService, IGuideService guideService)
        {
            this.reservationService = reservationService;
            this.routeService = routeService;
            this.guideService = guideService;
        }

        [Authorize]
        public IActionResult Add(int id)
        {
           var routeExist = this.routeService.CheckIfRouteExist(id);
            if (!routeExist)
            {
                return BadRequest();
            }

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

            var routeExist = this.routeService.CheckIfRouteExist(id);
            if (!routeExist)
            {
                return BadRequest();
            }

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
        [Authorize]
        public IActionResult UserReservations()
        {
            var reservations = this.reservationService.GetMyReservationsByUser(this.User.GetId());

            return this.View(reservations);
        }

        [Authorize]
        public IActionResult Cancel(int id)
        {
           var canUserCancelReservation =  this.reservationService
                .isUserAbleToRemoveReservation(id, this.User.GetId());

            if (!canUserCancelReservation)
            {
                return BadRequest();
            }

            this.reservationService.Cancel(id);

            return RedirectToAction(nameof(UserReservations));
        }

        [Authorize]
        public IActionResult Remove(int id)
        {
            var GuideCanRemove = this.guideService
                .CanGuideRemoveReservation(this.User.GetId(),id);

            if (GuideCanRemove || User.IsAdmin())
            {
                this.reservationService.Cancel(id);
            }
            else
            {
                return BadRequest();
            }
            return this.RedirectToAction("MyRoutes", "Routes");
        }
    }
}
