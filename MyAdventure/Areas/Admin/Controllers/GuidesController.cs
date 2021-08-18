using Microsoft.AspNetCore.Mvc;
using MyAdventure.Services.Guides;
using MyAdventure.Services.Routes;

namespace MyAdventure.Areas.Admin.Controllers
{
    public class GuidesController : AdminController
    {

        private readonly IRouteService routeService;
        private readonly IGuideService guideService;

        public GuidesController(IRouteService routeService, IGuideService guideService)
        {
            this.routeService = routeService;
            this.guideService = guideService;
        }
        public IActionResult AllGuides()
        {
            var guides = this.guideService.GetAllGuides();

            return this.View(guides);
        }
        public IActionResult AllGuideRoutes(int id)
        {
            var guideRoutes = this.routeService.GetRoutesByGuideId(id);

            return this.View(guideRoutes);
        }
        public IActionResult Remove(int id)
        {
            var isGuideExists = this.guideService.IsGuideExists(id);
            if (!isGuideExists)
            {
                return BadRequest();
            }
            var isRemoved =  this.guideService.IsRemoved(id);
            if (!isRemoved)
            {
                return BadRequest();
            }

            return RedirectToAction("AllGuides");
        }
    }
}
