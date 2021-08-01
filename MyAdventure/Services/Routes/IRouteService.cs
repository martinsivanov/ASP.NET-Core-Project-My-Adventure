namespace MyAdventure.Services.Routes
{
    using MyAdventure.Services.Routes.Models;
    using System.Collections.Generic;

    public interface IRouteService
    {
        RouteServiceQueryModel All(
            string mountain,
            string region,
            string searchTerm,
            int currentPage,
            int routesPerPage);

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
            int guideId);
        public bool EditRoute(int id, string name, string description, string duration, string imageUrl, string endPoint, string startPoint, string length, string mountain, string region, int seasonId, int categoryId, int guideId);

        IEnumerable<RouteServiceModel> MyRoutesByUser(string userId);

        IEnumerable<RouteCategoryServiceModel> GetRouteCategories();

        IEnumerable<RouteSeasonServiceModel> GetRouteSeasons();

        RouteDetailsServiceModel GetDetails(int routeId);

        public bool IsCategoryExist(int categoryId);
        public bool IsSeasonExist(int seasonId);
    }
}
