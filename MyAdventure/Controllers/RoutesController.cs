namespace MyAdventure.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MyAdventure.Data;
    using MyAdventure.Infrastructure;
    using MyAdventure.Models.Routes;
    using MyAdventure.Services.Routes;
    using MyAdventure.Services.Guides;

    using static MyAdventure.Areas.Admin.AdminConstants;
    using AutoMapper;

    public class RoutesController : Controller
    {
        private readonly MyAdventureDbContext data;
        private readonly IRouteService routeService;
        private readonly IGuideService guideService;
        private readonly IMapper mapper;

        public RoutesController(MyAdventureDbContext data, IRouteService routeService, IGuideService guideService, IMapper mapper)
        {
            this.data = data;
            this.routeService = routeService;
            this.guideService = guideService;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult MyRoutes()
        {
            var routes = this.routeService.MyRoutesByUser(this.User.GetId());

            return this.View(routes);
        }

        [Authorize]
        public IActionResult Add()
        {
            if (!this.guideService.IsGuide(this.User.GetId()))
            {
                return this.RedirectToAction(nameof(GuidesController.Become), "Guides");
            }

            return this.View(new RouteFormModel
            {
                Categories = this.routeService.GetRouteCategories(),
                Seasons = this.routeService.GetRouteSeasons()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(RouteFormModel route)
        {
            var guideId = this.guideService.GetGuideId(this.User.GetId());

            if (guideId == 0)
            {
                return this.RedirectToAction(nameof(GuidesController.Become), "Guides");
            }

            if (!this.routeService.IsCategoryExist(route.CategoryId))
            {
                this.ModelState.AddModelError(nameof(route.CategoryId), "Category does not exist.");
            }
            if (!this.routeService.IsSeasonExist(route.SeasonId))
            {
                this.ModelState.AddModelError(nameof(route.SeasonId), "Season does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                route.Categories = this.routeService.GetRouteCategories();
                route.Seasons = this.routeService.GetRouteSeasons();

                return this.View(route);
            }
            this.routeService.CreateRoute(
                route.Name,
                route.Description,
                route.Duration,
                route.ImageUrl,
                route.EndPoint,
                route.StartPoint,
                route.Length,
                route.Mountain,
                route.Region,
                route.SeasonId,
                route.CategoryId,
                route.DepartureTime,
                route.Price,
                route.Participants,
                guideId);
            return this.RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Edit(int Id)
        {
            var userId = this.User.GetId();

            if (!this.guideService.IsGuide(userId) && !User.IsAdmin())
            {
                return this.RedirectToAction(nameof(GuidesController.Become), "Guides");
            }

            var route = this.routeService.GetDetails(Id);

            if (route.UserId != userId && !User.IsAdmin())
            {
                return this.Unauthorized();
            }

            var routeForm = this.mapper.Map<RouteFormModel>(route);
            routeForm.Categories = this.routeService.GetRouteCategories();
            routeForm.Seasons = this.routeService.GetRouteSeasons();

            return this.View(routeForm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, RouteFormModel route)
        {
            var guideId = this.guideService.GetGuideId(this.User.GetId());

            if (guideId == 0 && !User.IsAdmin())
            {
                return this.RedirectToAction(nameof(GuidesController.Become), "Guides");
            }

            if (!this.routeService.IsCategoryExist(route.CategoryId))
            {
                this.ModelState.AddModelError(nameof(route.CategoryId), "Category does not exist.");
            }
            if (!this.routeService.IsSeasonExist(route.SeasonId))
            {
                this.ModelState.AddModelError(nameof(route.SeasonId), "Season does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                route.Categories = this.routeService.GetRouteCategories();
                route.Seasons = this.routeService.GetRouteSeasons();

                return this.View(route);
            }
            var isRouteEdited = this.routeService.EditRoute(
                id,
                route.Name,
                route.Description,
                route.Duration,
                route.ImageUrl,
                route.EndPoint,
                route.StartPoint,
                route.Length,
                route.Mountain,
                route.Region,
                route.SeasonId,
                route.CategoryId,
                route.DepartureTime,
                route.Price,
                route.Participants,
                guideId,
                User.IsAdmin());

            if (!isRouteEdited && !User.IsAdmin())
            {
                return this.BadRequest();
            }

            return this.RedirectToAction(nameof(MyRoutes));
        }

        public IActionResult All([FromQuery] AllRoutesQueryModel query)
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

        public IActionResult Details(int id)
        {
            var route = this.routeService.GetDetails(id);

            return this.View(route);
        }

        [Authorize(Roles = AdministratorRoleName)]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            this.routeService.DeleteRoute(id);

            return this.RedirectToAction(nameof(All));
        }
    }
}
