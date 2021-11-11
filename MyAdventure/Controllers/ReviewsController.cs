namespace MyAdventure.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Infrastructure;
    using MyAdventure.Models.Reviews;
    using MyAdventure.Services.Guides;
    using MyAdventure.Services.Reviews;
    using MyAdventure.Services.Reviews.Models;
    using MyAdventure.Services.Routes;

    using static MyAdventure.Data.DataConstants.Error;

    public class ReviewsController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly IGuideService guideService;
        private readonly IRouteService routeService;

        public ReviewsController(IReviewService reviewService, IGuideService guideService, IRouteService routeService)
        {
            this.reviewService = reviewService;
            this.guideService = guideService;
            this.routeService = routeService;
        }


        [Authorize]
        public IActionResult AllRouteReviews(int id)
        {
            var routeExist = this.routeService.CheckIfRouteExist(id);
            if (!routeExist)
            {
                return BadRequest();
            }

            var route = this.routeService.GetDetails(id);
            var reviews = this.reviewService.GetReviewsByRouteId(id);


            return this.View(new AllReviewsModel
            {
                ImageUrl = route.ImageUrl,
                Mountain = route.Mountain,
                RouteName = route.Name,
                Reviews = reviews,
                RouteId = route.Id,
                Description = route.Description
            });
        }

        [Authorize]
        public IActionResult AddReview(int id)
        {
            var routeExist = this.routeService.CheckIfRouteExist(id);
            if (!routeExist)
            {
                return BadRequest();
            }

            var userId = this.User.GetId();

            if (this.guideService.IsGuide(userId))
            {
                return BadRequest();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddReview(int id, ReviewFormModel reviewForm)
        {
            var userId = this.User.GetId();

            if (this.guideService.IsGuide(userId))
            {
                ModelState.AddModelError(userId, UserIsGuide);
            }
            if (!this.ModelState.IsValid)
            {
                return this.View(reviewForm);
            }
            var routeExist = this.routeService.CheckIfRouteExist(id);
            if (!routeExist)
            {
                return BadRequest();
            }
            var route = this.routeService.GetDetails(id);

            var review = new ReviewServiceModel
            {
                Content = reviewForm.Content,
                Name = reviewForm.Name
            };
            this.reviewService.CreateReview(route.Id, userId, review);
            return RedirectToAction("All", "Routes");
        }
    }
}
