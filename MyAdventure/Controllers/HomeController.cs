namespace MyAdventure.Controllers
{
    using MyAdventure.Models;

    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Data;
    using System.Linq;
    using MyAdventure.Models.Routes;
    using MyAdventure.Models.Home;

    public class HomeController : Controller
    {
        private readonly MyAdventureDbContext data;

        public HomeController(MyAdventureDbContext data)
        {
            this.data = data;
        }
        public IActionResult Index()
        {
            var totalRoutes = this.data.Routes.Count();

            var routes = this.data
                  .Routes
                  .OrderByDescending(x => x.Id)
                  .Select(x => new RouteListingViewModel
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
                TotalRoutes = totalRoutes
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel
            { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
