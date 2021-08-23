namespace MyAdventure.Areas.Admin.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyAdventure.Infrastructure;
    using MyAdventure.Models.Routes;
    using MyAdventure.Services.Routes;

    public class RoutesController : AdminController
    {
        private readonly IRouteService routeService;
        private readonly IMapper mapper;

        public RoutesController(IRouteService routeService, IMapper mapper)
        {
            this.routeService = routeService;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult All([FromQuery] AllRoutesQueryModel query)
        {
           var routes = this.routeService.All(
            query.Mountain,
            query.Region,
            query.SearchTerm,
            query.CurrentPage,
            AllRoutesQueryModel.RoutesPerPage,
            this.User.GetId()).Routes;

            return this.View(routes);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var route = this.routeService.GetDetails(id);

            if (route == null || !this.User.IsAdmin())
            {
                return BadRequest();
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

            if (!User.IsAdmin())
            {
                this.ModelState.AddModelError("Admin", "You are not admin.");
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
                0,
                User.IsAdmin());

            if (!isRouteEdited)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var routeExists = this.routeService.CheckIfRouteExist(id);
            if (!routeExists || !this.User.IsAdmin())
            {
                return BadRequest();
            }
            this.routeService.DeleteRoute(id);

            return this.RedirectToAction(nameof(All));
        }
    }
}
