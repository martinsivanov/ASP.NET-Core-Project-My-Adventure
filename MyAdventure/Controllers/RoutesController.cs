namespace MyAdventure.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    using MyAdventure.Data;
    using MyAdventure.Data.Models;
    using MyAdventure.Infrastructure;
    using MyAdventure.Models.Routes;
    using MyAdventure.Services.Routes;

    public class RoutesController : Controller
    {
        private readonly MyAdventureDbContext data;
        private readonly IRouteService routeService;

        public RoutesController(MyAdventureDbContext data, IRouteService routeService)
        {
            this.data = data;
            this.routeService = routeService;
        }

        [Authorize]
        public IActionResult Add()
        {

            if (!this.IsUserGuide())
            {
                return this.RedirectToAction(nameof(GuidesController.Become), "Guides");
            }

            return this.View(new AddRouteFormModel
            {
                Categories = GetRouteCategories(),
                Seasons = GetRouteSeasons()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddRouteFormModel route)
        {
            var guideId = this.data.Guides
                .Where(x => x.UserId == this.User.GetId())
                .Select(x => x.Id)
                .FirstOrDefault();

            if (guideId == 0)
            {
                return this.RedirectToAction(nameof(GuidesController.Become), "Guides");
            }

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
                CategoryId = route.CategoryId,
                GuideId = guideId
            };
            this.data.Routes.Add(routeData);
            this.data.SaveChanges();

            return this.RedirectToAction(nameof(All));
        }
        public IActionResult All([FromQuery]AllRoutesQueryModel query)
        {
            var routesQuery = this.routeService.All(
            query.Mountain,
            query.Region,
            query.SearchTerm,
            query.CurrentPage,
            AllRoutesQueryModel.RoutesPerPage);



            query.Routes = routesQuery.Routes;
            query.Regions = routesQuery.Regions;
            query.Mountains = routesQuery.Mountains;
            query.TotalRoutes = routesQuery.TotalRoutes;

            return this.View(query);
        }

        private bool IsUserGuide()
        => this.data
                .Guides
                .Any(x => x.UserId == this.User.GetId());

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
