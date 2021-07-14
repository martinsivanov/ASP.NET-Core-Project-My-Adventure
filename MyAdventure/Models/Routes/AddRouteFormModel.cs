namespace MyAdventure.Models.Routes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddRouteFormModel
    {
        [Required]
        [MaxLength(RouteNameMaxLength)]
        [MinLength(RouteNameMinLength)]
        public string Name { get; init; }

        [Required]
        [MaxLength(RouteDescriptionMaxLenght)]
        [MinLength(RouteDescriptionMinLenght)]
        public string Description { get; init; }

        [Url]
        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Required]
        [MaxLength(RouteStartPointMaxLenght)]
        [MinLength(RouteStartPointMinLenght)]
        public string StartPoint { get; init; }

        [Required]
        [MaxLength(RouteEndPointMaxLenght)]
        [MinLength(RouteEndPointMinLenght)]
        public string EndPoint { get; init; }

        [Required]
        [MaxLength(RouteDurationMaxLenght)]
        [MinLength(RouteDurationMinLenght)]
        public string Duration { get; init; }

        [Required]
        [MaxLength(RouteMaxLenght)]
        [MinLength(RouteMaxLenght)]
        public string Length { get; init; }

        [Required]
        [MaxLength(RegionMaxLenght)]
        [MinLength(RegionMinLenght)]
        public string Region { get; init; }

        [Required]
        [MaxLength(MountainMaxLenght)]
        [MinLength(MountainMinLenght)]
        public string Mountain { get; init; }

        public int CategoryId { get; set; }

        public ICollection<RouteCategoryViewModel> Categories { get; set; }

        public int SeasonId { get; set; }

        public ICollection<RouteSeasonViewModel> Seasons { get; set; }
    }
}
