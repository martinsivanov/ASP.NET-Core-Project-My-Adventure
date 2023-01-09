namespace MyAdventure.Models.Routes
{
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Services.Routes.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Route;

    public class RouteFormModel
    {
        [Required(ErrorMessage = "Name of route is required.")]
        [StringLength(RouteNameMaxLength, ErrorMessage = "Name of route must be between {2} и {1} symbols.", MinimumLength = RouteNameMinLength)]
        [Display(Name = "Name of route:")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(RouteDescriptionMaxLenght, ErrorMessage = "Description must be between {2} и {1} symbols.", MinimumLength = RouteDescriptionMinLenght)]
        [Display(Name = "Description:")]
        public string Description { get; init; }

        [Url(ErrorMessage = "Url is not valid")]
        [Required(ErrorMessage = "Image url is required.")]
        [Display(Name = "Image url")]
        public string ImageUrl { get; init; }

        [Required(ErrorMessage = "Start point is required.")]
        [StringLength(RouteStartPointMaxLength, ErrorMessage = "Start point must be between {2} и {1} symbols.", MinimumLength = RouteStartPointMinLength)]
        [Display(Name = "Start point:")]
        public string StartPoint { get; init; }

        [Required(ErrorMessage = "End point is required.")]
        [StringLength(RouteEndPointMaxLength, ErrorMessage = "End point must be between {2} и {1} symbols.", MinimumLength = RouteEndPointMinLength)]
        [Display(Name = "End point:")]
        public string EndPoint { get; init; }

        [Required(ErrorMessage = "Duration is required.")]
        [StringLength(RouteDurationMaxLength, ErrorMessage = "Duration must be between {2} и {1} symbols.", MinimumLength = RouteDurationMinLength)]
        [Display(Name = "Duration:")]
        public string Duration { get; init; }

        [Required(ErrorMessage = "Length of route is required.")]
        [StringLength(RouteMaxLength, ErrorMessage = "Length of route must be between {2} и {1} symbols.", MinimumLength = RouteMinLength)]
        [Display(Name = "Length of the route:")]
        public string Length { get; init; }

        [Required(ErrorMessage = "Region is required.")]
        [StringLength(RegionMaxLength, ErrorMessage = "Name of region must be between {2} и {1} symbols.", MinimumLength = RegionMinLength)]
        [Display(Name = "Region:")]
        public string Region { get; init; }

        [Required(ErrorMessage = "Mountain name is required.")]
        [StringLength(MountainMaxLength, ErrorMessage = "Name of the mountain must be between {2} и {1} symbols.", MinimumLength = MountainMinLength)]
        [Display(Name = "Mountain:")]
        public string Mountain { get; init; }

        [Required(ErrorMessage = "Date of departure time is required.")]
        [Display(Name = "Date of start:")]
        public DateTime DepartureTime { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Price:")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Number of participants is required.")]
        [Display(Name = "Number of participants:")]
        [Range(RouteMinParticipants,RouteMaxParticipants, ErrorMessage = "Number of participants must be between {2} и {1} people.")]
        public int Participants { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<RouteCategoryServiceModel> Categories { get; set; }

        public int SeasonId { get; set; }

        public IEnumerable<RouteSeasonServiceModel> Seasons { get; set; }
    }
}
