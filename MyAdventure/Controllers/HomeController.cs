namespace MyAdventure.Controllers
{
    using MyAdventure.Models;

    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Data;
    using System.Linq;
    using MyAdventure.Models.Routes;
    using MyAdventure.Models.Home;
    using MyAdventure.Services.Statistics;

    public class HomeController : Controller
    {
        private readonly MyAdventureDbContext data;
        private readonly IStatisticService statistics;

        public HomeController(MyAdventureDbContext data , IStatisticService statistics)
        {
            this.data = data;
            this.statistics = statistics;
        }
        public IActionResult Index()
        {
            var totalRoutes = this.statistics.GetTotal().TotalRoutes;
            var totalUsers = this.statistics.GetTotal().TotalUsers;

            var routes = this.data
                  .Routes
                  .OrderByDescending(x => x.Id)
                  .Select(x => new RouteIndexViewModel
                  {
                      Id = x.Id,
                      ImageUrl = x.ImageUrl,
                      Mountain = x.Mountain,
                      Name = x.Name,
                      Region = x.Region
                  })
                  .Take(3)
                  .ToList();

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
