namespace MyAdventure.Data.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int RouteId { get; set; }

        public Route Route { get; set; }
    }
}
