using MyAdventure.Data;
using MyAdventure.Data.Models;
using MyAdventure.Services.Reservations.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyAdventure.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly MyAdventureDbContext data;

        public ReservationService(MyAdventureDbContext data)
        {
            this.data = data;
        }

        public Route GetRoute(int id)
        {
            return this.data.Routes.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<ReservationServiceModel> GetMyReservationsByUser(string userId)
        {
            return this.GetReservations(this.data.Reservations
                .Where(x => x.UserId == userId));
        }
        public void Cancel(int reservationId)
        {
            var reservation = this.data.Reservations.FirstOrDefault(x => x.Id == reservationId);
            this.data.Reservations.Remove(reservation);
            this.data.SaveChanges();
        }
        private IEnumerable<ReservationServiceModel> GetReservations(IQueryable<Reservation> reservations)
        {
            return reservations.Select(x => new ReservationServiceModel
            {
                Id = x.Id,
                RouteName = x.Route.Name,
                RouteMountain = x.Route.Mountain,
                RouteRegion = x.Route.Region,
                GuideName = x.Guide.Name,
                RouteDate = x.Route.DepartureTime
            })
            .ToList();
        }
    }
}
