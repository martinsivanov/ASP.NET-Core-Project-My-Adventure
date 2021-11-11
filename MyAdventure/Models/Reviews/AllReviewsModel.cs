namespace MyAdventure.Models.Reviews
{
    using MyAdventure.Services.Reviews.Models;
    using System.Collections.Generic;

    public class AllReviewsModel
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string ImageUrl { get; set; }
        public string Mountain { get; set; }
        public  string Description { get; set; }
        public int ReviewId { get; set; }

        public IEnumerable<ReviewServiceModel> Reviews { get; set; }
    }
}
