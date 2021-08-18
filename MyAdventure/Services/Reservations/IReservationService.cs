namespace MyAdventure.Services.Reservations
{
    using MyAdventure.Services.Reservations.Models;
    using System.Collections.Generic;

    public interface IReservationService
    {

        public IEnumerable<ReservationServiceModel> GetMyReservationsByUser(string userId);

        public void Cancel(int reservationId);

        public bool AddReservation(int routeId, int guideId, string userId, string UserFirstName, string userLastName, string userCity, string userPhoneNumber);

        public bool CheckIfUserExistsInRoute(string userId,int routeId);

        public bool isUserAbleToRemoveReservation(int reservationId,string userId);
    }
}
