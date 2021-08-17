﻿using System.Collections.Generic;

namespace MyAdventure.Models.Reviews
{
    public class AllReviewsModel
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string ImageUrl { get; set; }
        public string Mountain { get; set; }

        public IEnumerable<ReviewFormModel> Reviews { get; set; }
    }
}