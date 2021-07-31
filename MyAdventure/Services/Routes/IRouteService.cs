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
    }
}
