using MyAdventure.Models.Routes;
using System.Collections.Generic;

namespace MyAdventure.Models.Home
{
    public class IndexViewModel
    {
        public int TotalRoutes { get; init; }

        public int TotalUsers { get; init; }

        public IEnumerable<RouteIndexViewModel> Routes { get; init; }
    }
}
