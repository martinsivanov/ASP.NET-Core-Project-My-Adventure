using MyAdventure.Data.Models;
using MyAdventure.Services.Reservations.Models;
using System.Collections.Generic;

namespace MyAdventure.Services.Reservations
{
    public interface IReservationService
    {
        public Route GetRoute(int id);

        public IEnumerable<ReservationServiceModel> GetMyReservationsByUser(string userId);

        public void Cancel(int reservationId);
    }
}
