namespace MyAdventure.Services.Reservations.Models
{
    using System;

    public class ReservationServiceModel
    {
        public int Id { get; set; }

        public string RouteName { get; set; }

        public string RouteMountain { get; set; }

        public string RouteRegion { get; set; }

        public DateTime RouteDate { get; set; }

        public string GuideName { get; set; }
    }
}
