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
        [Display(Name = "Име на маршрута:")]
        public string Name { get; init; }

        [Required]
        [MaxLength(RouteDescriptionMaxLenght)]
        [MinLength(RouteDescriptionMinLenght)]
        [Display(Name ="Описание:")]
        public string Description { get; init; }

        [Url]
        [Required]
        [Display(Name = "Снимка URL")]
        public string ImageUrl { get; init; }

        [Required]
        [MaxLength(RouteStartPointMaxLenght)]
        [MinLength(RouteStartPointMinLenght)]
        [Display(Name = "Начална точка:")]
        public string StartPoint { get; init; }

        [Required]
        [MaxLength(RouteEndPointMaxLenght)]
        [MinLength(RouteEndPointMinLenght)]
        [Display(Name = "Крайна точка:")]
        public string EndPoint { get; init; }

        [Required]
        [MaxLength(RouteDurationMaxLenght)]
        [MinLength(RouteDurationMinLenght)]
        [Display(Name = "Времетраене:")]
        public string Duration { get; init; }

        [Required]
        [MaxLength(RouteMaxLenght)]
        [MinLength(RouteMinLenght)]
        [Display(Name = "Дължина:")]
        public string Length { get; init; }

        [Required]
        [MaxLength(RegionMaxLenght)]
        [MinLength(RegionMinLenght)]
        [Display(Name = "Регион:")]
        public string Region { get; init; }

        [Required]
        [MaxLength(MountainMaxLenght)]
        [MinLength(MountainMinLenght)]
        [Display(Name = "Планина:")]
        public string Mountain { get; init; }

        public int CategoryId { get; set; }

        public ICollection<RouteCategoryViewModel> Categories { get; set; }

        public int SeasonId { get; set; }

        public ICollection<RouteSeasonViewModel> Seasons { get; set; }
    }
}
