namespace MyAdventure.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Data;
    using MyAdventure.Data.Models;
    using MyAdventure.Infrastructure;
    using MyAdventure.Models.Reservations;
    using MyAdventure.Services.Reservations;
    using System.Collections.Generic;
    using System.Linq;

    public class ReservationsController : Controller
    {
        private readonly IReservationService reservationService;
        private readonly MyAdventureDbContext data;

        public ReservationsController(IReservationService reservationService, MyAdventureDbContext data)
        {
            this.reservationService = reservationService;
            this.data = data;
        }

        [Authorize]
        public IActionResult Add(int id)
        {
            var route = reservationService.GetRoute(id);

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

            var route = reservationService.GetRoute(id);

            var user = this.data.Users.Where(x => x.Id == this.User.GetId()).FirstOrDefault();

            user.PhoneNumber = reservationForm.PhoneNumber;


            var reservation = new Reservation
            {
                RouteId = route.Id,
                GuideId = route.GuideId,
                UserId = this.User.GetId(),
                UserFirstName = reservationForm.FistName,
                UserLastName = reservationForm.LastName,
                UserCity = reservationForm.City,
                UserPhoneNumber = reservationForm.PhoneNumber
            };

            this.data.Reservations.Add(reservation);
            route.Participants -= 1;
            this.data.SaveChanges();

            var reservations = this.data.Reservations.Where(x => x.RouteId == id).ToList();


            return this.RedirectToAction(nameof(UserReservations));
        }

        public IActionResult UserReservations()
        {
            var reservations = this.reservationService.GetMyReservationsByUser(this.User.GetId());

            return this.View(reservations);
        }

        public IActionResult Cancel(int id)
        {
            this.reservationService.Cancel(id);

            return RedirectToAction(nameof(UserReservations));
        }
    }
}
