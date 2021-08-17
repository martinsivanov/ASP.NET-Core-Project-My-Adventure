namespace MyAdventure.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Models.Routes;
    using MyAdventure.Services.Routes;

    using MyAdventure.Infrastructure;

    public class RoutesController : AdminController
    {
        private readonly IRouteService routeService;

        public RoutesController(IRouteService routeService)
        {
            this.routeService = routeService;
        }

    }
}
