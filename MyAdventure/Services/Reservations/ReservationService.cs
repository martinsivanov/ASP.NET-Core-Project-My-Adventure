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


        public IEnumerable<ReservationServiceModel> GetMyReservationsByUser(string userId)
        {
            return this.GetReservations(this.data.Reservations
                .Where(x => x.UserId == userId));
        }
        public bool AddReservation(int routeId, int guideId, string userId, string userFirstName, string userLastName, string userCity, string userPhoneNumber)
        {
            var reservation = new Reservation
            {
                RouteId = routeId,
                GuideId = guideId,
                UserId = userId,
                UserFirstName = userFirstName,
                UserLastName = userLastName,
                UserCity = userCity,
                UserPhoneNumber = userPhoneNumber
            };

            var route = this.data.Routes.FirstOrDefault(x => x.Id == routeId);
            if (route.Participants <= 0)
            {
                return false;
            }
            route.Participants -= 1;

            this.data.Reservations.Add(reservation);
            this.data.SaveChanges();

            return true;
        }

        public void Cancel(int reservationId)
        {
            var reservation = this.data.Reservations.FirstOrDefault(x => x.Id == reservationId);
            var route = this.data.Routes.FirstOrDefault(x => x.Id == reservation.RouteId);

            route.Participants += 1;

            this.data.Reservations.Remove(reservation);
            this.data.SaveChanges();
        }
        
        public bool CheckIfUserExistsInRoute(string userId, int routeId)
        {
            return this.data.Reservations.Where(x => x.RouteId == routeId).Any(x => x.UserId == userId);
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
