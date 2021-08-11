namespace MyAdventure.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Data;
    using MyAdventure.Data.Models;
    using MyAdventure.Infrastructure;
    using MyAdventure.Models.Reservations;
    using System.Linq;

    public class ReservationsController : Controller
    {
        private readonly MyAdventureDbContext data;

        public ReservationsController(MyAdventureDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add(int id)
        {
            var route = this.data.Routes.Where(x => x.Id == id).FirstOrDefault();

            var userId = this.User.GetId();

            //var checkUserId = this.data.Reservations.Where(x => x.)

            var reservation = new Reservation
            {
                RouteId = route.Id,
                GuideId = route.GuideId,
                AvailableParticipants = route.Participants
            };

            var reservationForm = new ReservationFormModel
            {
                RouteName = route.Name
            };

            return View(reservationForm);
        }
    }
}
