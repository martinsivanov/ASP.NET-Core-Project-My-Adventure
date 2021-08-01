using MyAdventure.Data;
using MyAdventure.Services.Statistics.Models;
using System.Linq;

namespace MyAdventure.Services.Statistics
{
    public class StatisticService : IStatisticService
    {
        private readonly MyAdventureDbContext data;

        public StatisticService(MyAdventureDbContext data)
        {
            this.data = data;
        }

        public StatisticsServiceModel GetTotal()
        {
            var totalRoutes =  this.data.Routes.Count();
            var totalUsers = this.data.Users.Count();

            return new StatisticsServiceModel
            {
                TotalRoutes = totalRoutes,
                TotalUsers = totalUsers
            };
        }
    }
}
