using MyAdventure.Models.Reviews;
using System.Collections.Generic;

namespace MyAdventure.Services.Reviews
{
    public interface IReviewService
    {
        public void CreateReview(int routeId, string userId, ReviewFormModel reviewForm);

        public ICollection<ReviewFormModel> GetReviewsByRouteId(int routeId);

        public bool IsUserAlreadyAddReview(string userId);


    }
}
