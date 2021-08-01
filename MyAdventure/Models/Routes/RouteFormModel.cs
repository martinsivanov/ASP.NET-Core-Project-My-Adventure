namespace MyAdventure.Models.Routes
{
    using MyAdventure.Services.Routes.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Route;

    public class RouteFormModel
    {
        [Required(ErrorMessage = "Името на маршрута не е попълнено.")]
        [StringLength(RouteNameMaxLength, ErrorMessage = "Името на маршрута трябва да е между {2} и {1} символа.", MinimumLength = RouteNameMinLength)]
        [Display(Name = "Име на маршрута:")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Описанието не е попълнено.")]
        [StringLength(RouteDescriptionMaxLenght, ErrorMessage = "Описанието трябва да е между {2} и {1} символа.", MinimumLength = RouteDescriptionMinLenght)]
        [Display(Name = "Описание:")]
        public string Description { get; init; }

        [Url(ErrorMessage = "Невалиден адрес на снимката.")]
        [Required(ErrorMessage = "Адресът на снимката не е попълнен.")]
        [Display(Name = "Адрес на снимката")]
        public string ImageUrl { get; init; }

        [Required(ErrorMessage = "Началната точка не е попълнена.")]
        [StringLength(RouteStartPointMaxLenght, ErrorMessage = "Начална точка трябва да е между {2} и {1} символа.", MinimumLength = RouteStartPointMinLenght)]
        [Display(Name = "Начална точка:")]
        public string StartPoint { get; init; }

        [Required(ErrorMessage = "Крайната точка не е попълнена.")]
        [StringLength(RouteEndPointMaxLenght, ErrorMessage = "Крайна точка трябва да е между {2} и {1} символа.", MinimumLength = RouteEndPointMinLenght)]
        [Display(Name = "Крайна точка:")]
        public string EndPoint { get; init; }

        [Required(ErrorMessage = "Времетраенето не е попълнено.")]
        [StringLength(RouteDurationMaxLenght, ErrorMessage = "Времетраенето трябва да е между {2} и {1} символа.", MinimumLength = RouteDurationMinLenght)]
        [Display(Name = "Времетраене:")]
        public string Duration { get; init; }

        [Required(ErrorMessage = "Дължината не е попълнена.")]
        [StringLength(RouteMaxLenght, ErrorMessage = "Дължината трябва да е между {2} и {1} символа.", MinimumLength = RouteMinLenght)]
        [Display(Name = "Дължина:")]
        public string Length { get; init; }

        [Required(ErrorMessage = "Името на региона не е попълнен.")]
        [StringLength(RegionMaxLenght, ErrorMessage = "Името на ригиона трябва да е между {2} и {1} символа.", MinimumLength = RegionMinLenght)]
        [Display(Name = "Регион:")]
        public string Region { get; init; }

        [Required(ErrorMessage = "Името на планината не е попълнено.")]
        [StringLength(MountainMaxLenght, ErrorMessage = "Името на планината трябва да е между {2} и {1} символа.", MinimumLength = MountainMinLenght)]
        [Display(Name = "Планина:")]
        public string Mountain { get; init; }

        public int CategoryId { get; set; }

        public IEnumerable<RouteCategoryServiceModel> Categories { get; set; }

        public int SeasonId { get; set; }

        public IEnumerable<RouteSeasonServiceModel> Seasons { get; set; }
    }
}
