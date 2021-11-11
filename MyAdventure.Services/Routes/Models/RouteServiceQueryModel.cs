using System.Collections.Generic;

namespace MyAdventure.Services.Routes.Models
{

    public class RouteServiceQueryModel
    {
        public int RoutesPerPage { get; init; }

        public int CurrentPage { get; init; }

        public int TotalRoutes { get; set; }

        public IEnumerable<RouteServiceModel> Routes { get; init; }
        public IEnumerable<string> Mountains { get; init; }
        public IEnumerable<string> Regions { get; init; }
    }
}
