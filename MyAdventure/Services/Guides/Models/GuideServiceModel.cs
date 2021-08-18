using MyAdventure.Services.Routes.Models;
using System.Collections.Generic;

namespace MyAdventure.Services.Guides.Models
{
    public class GuideServiceModel
    {
        public int GuideId { get; set; }

        public string GuideName { get; set; }

        public string PhoneNumber { get; set; }

        public IEnumerable<RouteServiceModel> Routes { get; set; }
    }
}
