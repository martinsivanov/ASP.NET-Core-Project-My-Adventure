namespace MyAdventure.Services.Reviews
{
    using MyAdventure.Data;
    using MyAdventure.Data.Models;
    using MyAdventure.Services.Reviews.Models;
    using MyAdventure.Services.Routes.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ReviewService : IReviewService
    {
        private readonly MyAdventureDbContext data;

        public ReviewService(MyAdventureDbContext data)
        {
            this.data = data;
        }

        public ICollection<ReviewServiceModel> GetReviewsByRouteId(int routeId)
        {
            var reviews = this.data.Reviews
                .Where(x => x.RouteId == routeId)
                .Select(x => new ReviewServiceModel
                {
                    Name = x.UserName,
                    Content = x.Content,
                })
                .ToList();

            return reviews;

        }

        public void CreateReview(int routeId, string userId, ReviewServiceModel reviewForm)
        {
            var user = this.data.Users.Find(userId);

            var review = new Review
            {
                RouteId = routeId,
                UserId = userId,
                UserName = reviewForm.Name,
                Content = reviewForm.Content
            };

            this.data.Reviews.Add(review);
            this.data.SaveChanges();
        }

        public bool IsUserAlreadyAddReview(string userId)
        {
            return this.data.Reviews.Any(x => x.UserId == userId);
        }
    }
}
