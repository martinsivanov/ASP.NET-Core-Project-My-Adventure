using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAdventure.Models.Routes
{
    public class AllRoutesQueryModel
    {
        public const int RoutesPerPage = 3;

        [Display(Name = "Област")]
        public string Region { get; set; }

        public IEnumerable<string> Regions { get; set; }

        [Display(Name = "Планина")]
        public string Mountain { get; set; }

        public IEnumerable<string> Mountains { get; set; }

        [Display(Name = "Търсене:")]
        public string SearchTerm { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalRoutes { get; set; }

        public  IEnumerable<RouteListingViewModel> Routes { get; set; }

    }
}
