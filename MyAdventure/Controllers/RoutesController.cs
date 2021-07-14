namespace MyAdventure.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Data;
    using MyAdventure.Data.Models;
    using MyAdventure.Models.Routes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RoutesController : Controller
    {
        private readonly MyAdventureDbContext data;

        public RoutesController(MyAdventureDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            return this.View(new AddRouteFormModel
            {
                Categories = GetRouteCategories(),
                Seasons = GetRouteSeasons()
            });
        }

        [HttpPost]
        public IActionResult Add(AddRouteFormModel route)
        {
            if (!this.data.Categories.Any(c => c.Id == route.CategoryId))
            {
                this.ModelState.AddModelError(nameof(route.CategoryId), "Category does not exist.");
            }
            if (!this.data.Seasons.Any(s => s.Id == route.SeasonId))
            {
                this.ModelState.AddModelError(nameof(route.SeasonId), "Season does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                route.Categories = this.GetRouteCategories();
                route.Seasons = this.GetRouteSeasons();

                return this.View(route);
            }
            var routeData = new Route
            {
                Name = route.Name,
                Description = route.Description,
                Duration = route.Duration,
                ImageUrl = route.ImageUrl,
                StartPoint = route.StartPoint,
                EndPoint = route.EndPoint,
                Length = route.Length,
                Mountain = route.Mountain,
                Region = route.Region,
                SeasonId = route.SeasonId,
                CategoryId = route.CategoryId
            };
            this.data.Routes.Add(routeData);
            this.data.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }

        private ICollection<RouteSeasonViewModel> GetRouteSeasons()
        {
            return this.data.Seasons
                 .Select(x => new RouteSeasonViewModel
                 {
                     Id = x.Id,
                     Name = x.Name

                 }).ToList();
        }
        private ICollection<RouteCategoryViewModel> GetRouteCategories()
        {
            return this.data.Categories
                 .Select(x => new RouteCategoryViewModel
                 {
                     Id = x.Id,
                     Name = x.Name

                 }).ToList();
        }
    }
}
