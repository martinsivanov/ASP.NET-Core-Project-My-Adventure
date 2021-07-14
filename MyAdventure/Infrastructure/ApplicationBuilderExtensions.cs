namespace MyAdventure.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MyAdventure.Data;
    using MyAdventure.Data.Models;
    using System.Linq;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
           this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<MyAdventureDbContext>();

            data.Database.Migrate();

            SeedCategories(data);
            SeedSeasons(data);

            return app;
        }

        private static void SeedCategories(MyAdventureDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Walking" },
                new Category { Name = "Cycling" },
            });

            data.SaveChanges();
        }

        private static void SeedSeasons(MyAdventureDbContext data)
        {
            if (data.Seasons.Any())
            {
                return;
            }

            data.Seasons.AddRange(new[]
            {
                new Season { Name = "Summer" },
                new Season { Name = "Winter" },
            });

            data.SaveChanges();
        }
    }
}
