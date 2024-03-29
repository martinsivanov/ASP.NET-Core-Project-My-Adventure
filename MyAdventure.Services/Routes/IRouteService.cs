﻿namespace MyAdventure.Services.Routes
{
    using MyAdventure.Services.Routes.Models;
    using System;
    using System.Collections.Generic;

    public interface IRouteService
    {
        public IEnumerable<RouteServiceLastest> LastestRoute();
        public IEnumerable<RouteServiceModel> GetRoutesByGuideId(int guideId);

        RouteServiceQueryModel All(
            string mountain,
            string region,
            string searchTerm,
            int currentPage,
            int routesPerPage,
            string userId);

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
            DateTime date,
            string price,
            int participants,
            int guideId);
        public bool EditRoute(int id, string name, string description, string duration, string imageUrl, string endPoint, string startPoint, string length, string mountain, string region, int seasonId, int categoryId, DateTime date,
            string price, int participants, int guideId, bool isAdmin);

        public void DeleteRoute(int routeId);

        IEnumerable<RouteServiceModel> MyRoutesByUser(string userId);

        IEnumerable<RouteCategoryServiceModel> GetRouteCategories();

        IEnumerable<RouteSeasonServiceModel> GetRouteSeasons();

        RouteDetailsServiceModel GetDetails(int routeId);

        public bool IsCategoryExist(int categoryId);
        public bool IsSeasonExist(int seasonId);

        public bool CheckIfRouteExist(int routeId);
    }
}