using MyAdventure.Data;
using MyAdventure.Data.Models;
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
    }
}
