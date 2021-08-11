namespace MyAdventure.Services.Routes
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MyAdventure.Data;
    using MyAdventure.Data.Models;
    using MyAdventure.Services.Routes.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class RouteService : IRouteService
    {
        private readonly MyAdventureDbContext data;
        private readonly IMapper mapper;

        public RouteService(MyAdventureDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
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

            var routes = this.GetRoutes(routesQuery
                .Skip((currentPage - 1) * routesPerPage)
                .Take(routesPerPage));

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

        public int CreateRoute(
            string name,
            string description,
            string duration,
            string imageUrl,
            string endPoint,
            string startPoint,
            string length,
            string mountain,
            string region,
            int seasonId,
            int categoryId,
            string date,
            string price,
            int guideId
            )
        {
            var route = new Route
            {
                Name = name,
                Description = description,
                Duration = duration,
                ImageUrl = imageUrl,
                StartPoint = startPoint,
                EndPoint = endPoint,
                Length = length,
                Mountain = mountain,
                Region = region,
                SeasonId = seasonId,
                CategoryId = categoryId,
                GuideId = guideId,
                Date = date,
                Price = price
            };
            this.data.Routes.Add(route);
            this.data.SaveChanges();

            return route.Id;
        }

        public bool EditRoute(int id, string name, string description, string duration, string imageUrl, string endPoint, string startPoint, string length, string mountain, string region, int seasonId, int categoryId, string date, string price, int guideId, bool isAdmin)
        {
            var routeData = this.data.Routes.Where(x => x.Id == id).FirstOrDefault();

            if (routeData.GuideId != guideId && !isAdmin)
            {
                return false;
            }

            routeData.Name = name;
            routeData.Description = description;
            routeData.Duration = duration;
            routeData.ImageUrl = imageUrl;
            routeData.StartPoint = startPoint;
            routeData.EndPoint = endPoint;
            routeData.Length = length;
            routeData.Mountain = mountain;
            routeData.Region = region;
            routeData.SeasonId = seasonId;
            routeData.CategoryId = categoryId;
            //routeData.GuideId = guideId;
            routeData.Price = price;
            routeData.Date = date;

            this.data.SaveChanges();

            return true;
        }
        public void DeleteRoute(int routeId)
        {
            var route = this.data.Routes.FirstOrDefault(x => x.Id == routeId);
            this.data.Remove(route);
            this.data.SaveChanges();
        }
        public RouteDetailsServiceModel GetDetails(int routeId)
        {
            var route = this.data.Routes
                .Where(x => x.Id == routeId)
                .ProjectTo<RouteDetailsServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

            return route;
        }

        public IEnumerable<RouteCategoryServiceModel> GetRouteCategories()
        {
            return this.data.Categories
                    .Select(x => new RouteCategoryServiceModel
                    {
                        Id = x.Id,
                        Name = x.Name

                    }).ToList();
        }

        public IEnumerable<RouteSeasonServiceModel> GetRouteSeasons()
        {
            return this.data.Seasons
                   .Select(x => new RouteSeasonServiceModel
                   {
                       Id = x.Id,
                       Name = x.Name
                   }).ToList();
        }

        public bool IsCategoryExist(int categoryId)
        {
            return this.data.Categories.Any(c => c.Id == categoryId);
        }
        public bool IsSeasonExist(int seasonId)
        {
            return this.data.Seasons.Any(s => s.Id == seasonId);
        }

        public IEnumerable<RouteServiceModel> MyRoutesByUser(string userId)
        {
            return this.GetRoutes(this.data.Routes
                .Where(x => x.Guide.UserId == userId));
        }

        private IEnumerable<RouteServiceModel> GetRoutes(IQueryable<Route> routes)
        {
            return routes.Select(x => new RouteServiceModel
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Mountain = x.Mountain,
                Name = x.Name,
                Region = x.Region
            })
            .ToList();
        }
    }
}
