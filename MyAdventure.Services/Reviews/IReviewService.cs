namespace MyAdventure.Services.Reviews
{
    using MyAdventure.Services.Reviews.Models;
    using System.Collections.Generic;

    public interface IReviewService
    {
        public void CreateReview(int routeId, string userId, ReviewServiceModel reviewForm);

        public ICollection<ReviewServiceModel> GetReviewsByRouteId(int routeId);

        public bool IsUserAlreadyAddReview(string userId);


    }
}
