namespace MyAdventure.Models.Home
{
    using System.Collections.Generic;
    using MyAdventure.Services.Routes.Models;

    public class IndexViewModel
    {
        public int TotalRoutes { get; init; }

        public int TotalUsers { get; init; }

        public IEnumerable<RouteServiceLastest> Routes { get; init; }
    }
}
