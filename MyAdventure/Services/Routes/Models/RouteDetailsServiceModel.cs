namespace MyAdventure.Services.Routes.Models
{
    public class RouteDetailsServiceModel : RouteServiceModel
    {

        public string Description { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public string Duration { get; set; }

        public string Length { get; set; }

        public string UserId { get; set; }

        public int SeasonId { get; set; }

        public int CategoryId { get; set; }

        public int GuideId { get; set; }

        public string GuideName { get; set; }
    }
}
