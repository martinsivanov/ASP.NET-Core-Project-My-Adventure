using MyAdventure.Data.Models;

namespace MyAdventure.Services.Reservations
{
    public interface IReservationService
    {
        public Route GetRoute(int id);
    }
}
