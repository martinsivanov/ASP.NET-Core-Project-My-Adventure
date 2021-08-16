namespace MyAdventure.Controllers
{
    using MyAdventure.Models;

    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Data;
    using MyAdventure.Models.Home;
    using MyAdventure.Services.Statistics;
    using AutoMapper;
    using MyAdventure.Services.Routes;

    public class HomeController : Controller
    {
        private readonly IStatisticService statistics;
        private readonly IMapper mapper;
        private readonly IRouteService routeService;

        public HomeController(MyAdventureDbContext data, IStatisticService statistics, IMapper mapper, IRouteService routeService)
        {
            this.statistics = statistics;
            this.mapper = mapper;
            this.routeService = routeService;
        }
        public IActionResult Index()
        {
            var totalRoutes = this.statistics.GetTotal().TotalRoutes;
            var totalUsers = this.statistics.GetTotal().TotalUsers;

            var routes = this.routeService.LastestRoute();

            return this.View(new IndexViewModel
            {
                Routes = routes,
                TotalRoutes = totalRoutes,
                TotalUsers = totalUsers
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel
            { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
