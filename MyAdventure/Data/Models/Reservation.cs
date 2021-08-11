using System.Collections.Generic;

namespace MyAdventure.Data.Models
{
    public class Reservation
    {
        public Reservation()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public int RouteId { get; set; }

        public int GuideId { get; set; }

        public int AvailableParticipants { get; set; }

        public decimal Price { get; set; }

        public Route Route { get; set; }

        public Guide Guide { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
