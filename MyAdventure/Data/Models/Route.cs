namespace MyAdventure.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class Route
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(RouteNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(RouteDescriptionMaxLenght)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        [Required]
        [MaxLength(RouteDurationMaxLenght)]
        public string Duration { get; set; }

        [Required]
        [MaxLength(RouteMaxLenght)]
        public string Length { get; set; }

        [Required]
        [MaxLength(RegionNameMaxLenght)]
        public string Region { get; set; }

        [Required]
        [MaxLength(MountainNameMaxLenght)]
        public string Mountain { get; set; }

        public int SeasonId { get; set; }

        public virtual Season Season { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
