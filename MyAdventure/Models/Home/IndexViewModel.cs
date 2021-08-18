namespace MyAdventure.Models.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public int TotalRoutes { get; init; }

        public int TotalUsers { get; init; }

        public IEnumerable<RouteIndexViewModel> Routes { get; init; }
    }
}
