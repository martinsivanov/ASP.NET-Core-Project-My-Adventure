namespace MyAdventure.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Infrastructure;
    using MyAdventure.Models.Guides;
    using MyAdventure.Services.Guides;
    using MyAdventure.Services.Routes;
    using static Data.DataConstants.Error;

    public class GuidesController : Controller
    {
        private readonly IGuideService guideService;
        private readonly IRouteService routeService;

        public GuidesController(IGuideService guideService, IRouteService routeService)
        {
            this.guideService = guideService;
            this.routeService = routeService;
        }

        [Authorize]
        public IActionResult Become()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeGuideFormModel guide)
        {
            var userId = this.User.GetId();

            var userIsAlreadyGuide = this.guideService.IsGuide(userId);

            if (userIsAlreadyGuide)
            {
                this.ModelState.AddModelError(nameof(guide), UserIsGuide);
            }

            if (!ModelState.IsValid)
            {
                return this.View(guide);
            }

            this.guideService.CreateGuide(guide.Name, guide.PhoneNumber, userId);

            return this.RedirectToAction("All", "Routes");
        }

        [Authorize]
        public IActionResult AllParticipants(int id)
        {
            var isGuide = this.guideService.IsGuide(this.User.GetId());

            var routeExist = this.routeService.CheckIfRouteExist(id);

            if (!routeExist || (!isGuide && !this.User.IsAdmin()))
            {
                return BadRequest();
            }

           var users = this.guideService.GetAllParticipantsByRouteId(id);

            return this.View(users);
        }
    }
}
