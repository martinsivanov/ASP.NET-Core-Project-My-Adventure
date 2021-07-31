namespace MyAdventure.Services.Routes
{
    using MyAdventure.Data;
    using MyAdventure.Services.Routes.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class RouteService : IRouteService
    {
        private readonly MyAdventureDbContext data;

        public RouteService(MyAdventureDbContext data)
        {
            this.data = data;
        }

        public RouteServiceQueryModel All(
            string mountain,
            string region,
            string searchTerm,
            int currentPage,
            int routesPerPage)
    {
        var routesQuery = this.data.Routes.AsQueryable();

        if (!string.IsNullOrEmpty(mountain))
        {
            routesQuery = this.data.Routes.Where(x => x.Mountain == mountain);
        }

        if (!string.IsNullOrEmpty(region))
        {
            routesQuery = this.data.Routes.Where(x => x.Region == region);
        }

        if (!string.IsNullOrEmpty(searchTerm))
        {
            routesQuery = routesQuery
                .Where(x => x.Name.ToLower() == searchTerm ||
            x.Region.ToLower() == searchTerm || x.Mountain.ToLower() == searchTerm);
        }

        var regions = this.data.Routes
            .Select(x => x.Region)
            .Distinct()
            .ToList();

        var mountains = this.data.Routes
            .Select(x => x.Mountain)
            .Distinct()
            .ToList();

        var totalRoutes = this.data.Routes.Count();

        var routes = routesQuery
            .Skip((currentPage - 1) * routesPerPage)
            .Take(routesPerPage)
            .Select(x => new RouteServiceModel
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Mountain = x.Mountain,
                Name = x.Name,
                Region = x.Region
            })
            .ToList();

        return new RouteServiceQueryModel
        {
            CurrentPage = currentPage,
            RoutesPerPage = routesPerPage,
            TotalRoutes = totalRoutes,
            Routes = routes,
            Mountains = mountains,
            Regions = regions
        };
    }
    }
}
