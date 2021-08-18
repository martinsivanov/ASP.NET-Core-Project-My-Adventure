namespace MyAdventure.Services.Reviews
{
    using MyAdventure.Models.Reviews;
    using System.Collections.Generic;

    public interface IReviewService
    {
        public void CreateReview(int routeId, string userId, ReviewFormModel reviewForm);

        public ICollection<ReviewFormModel> GetReviewsByRouteId(int routeId);

        public bool IsUserAlreadyAddReview(string userId);


    }
}
