namespace MyAdventure.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MyAdventure.Data;
    using MyAdventure.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using static MyAdventure.Areas.Admin.AdminConstants;
    using static MyAdventure.Data.DataConstants.SeedData;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
           this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedUser(services);
            SeedGuide(services);
            SeedCategories(services);
            SeedSeasons(services);
            SeedRoutes(services);
            SeedAdministrator(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<MyAdventureDbContext>();

            data.Database.Migrate();
        }

        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<MyAdventureDbContext>();

            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = FirstCategoryName },
                new Category { Name = SecondCategoryName },
            });

            data.SaveChanges();
        }

        private static void SeedSeasons(IServiceProvider services)
        {
            var data = services.GetRequiredService<MyAdventureDbContext>();

            if (data.Seasons.Any())
            {
                return;
            }

            data.Seasons.AddRange(new[]
            {
                new Season { Name = FirstSeasonName },
                new Season { Name = SecondSeasonName},
                new Season { Name = ThirdSeasonName },
                new Season { Name = FourthSeasonName}
            });

            data.SaveChanges();
        }
        private static void SeedGuide(IServiceProvider services)
        {
            var data = services.GetRequiredService<MyAdventureDbContext>();

            if (data.Guides.Any())
            {
                return;
            }
            var user = data.Users.Where(x => x.Email == GuideEmail).FirstOrDefault();
            var guide = new Guide
            {
                UserId = user.Id,
                Name = GuideName,
                PhoneNumber = GuidePhoneNumber
            };
            data.Guides.Add(guide);
            data.SaveChanges();
        }
        private static void SeedUser(IServiceProvider services)
        {
            var data = services.GetRequiredService<MyAdventureDbContext>();
            var userManager = services.GetRequiredService<UserManager<User>>();

            if (data.Users.Any())
            {
                return;
            }
            Task
               .Run(async () =>
               {
                   var guide = new User
                   {
                       UserName = GuideEmail,
                       Email = GuideEmail
                   };

                   await userManager.CreateAsync(guide, DefaultPassword);

                   var user = new User
                   {
                       UserName = UserEmail,
                       Email = UserEmail
                   };

                   await userManager.CreateAsync(user, DefaultPassword);
               })
               .GetAwaiter()
               .GetResult();
        }

        private static void SeedRoutes(IServiceProvider services)
        {
            var data = services.GetRequiredService<MyAdventureDbContext>();

            if (data.Routes.Any())
            {
                return;
            }
            var category = data.Categories.Where(x => x.Name == FirstCategoryName)
                .FirstOrDefault();
            var guide = data.Guides.Where(x => x.Name == GuideName).FirstOrDefault();
            var season = data.Seasons.Where(x => x.Name == FirstSeasonName).FirstOrDefault();

            data.Routes.AddRange(new[]
            {
                new Route
                {
                    Name = RouteName,
                    CategoryId = category.Id,
                    ImageUrl = RouteImageUrl,
                    Description = RouteDescription,
                    DepartureTime = RouteDepartureTime,
                    Duration = RouteDuration,
                    Mountain = RouteMountain,
                    Participants = RouteParticipants,
                    StartPoint = RouteStartPoint,
                    EndPoint = RouteEndPoint,
                    Length = RouteLength,
                    Price = RoutePrice,
                    GuideId = guide.Id,
                    Region = RouteRegion,
                    SeasonId = season.Id
                }
            });

            data.SaveChanges();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = AdminEmail;
                    const string adminPassword = AdminPassword;

                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
