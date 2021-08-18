namespace MyAdventure.Areas.Admin.Controllers
{
    using MyAdventure.Services.Routes;

    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Services.Guides;

    public class RoutesController : AdminController
    {
        private readonly IRouteService routeService;
        private readonly IGuideService guideService;

        public RoutesController(IRouteService routeService, IGuideService guideService)
        {
            this.routeService = routeService;
            this.guideService = guideService;
        }
        public IActionResult Remove(int id)
        {
            var routeExist = this.routeService.CheckIfRouteExist(id);
            if (!routeExist)
            {
                return BadRequest();
            }
            this.routeService.DeleteRoute(id);

            return RedirectToAction("AllGuides", "Guides");
        }
    }
}
