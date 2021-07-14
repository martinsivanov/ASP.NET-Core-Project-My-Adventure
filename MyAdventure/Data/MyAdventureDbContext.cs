namespace MyAdventure.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MyAdventure.Data.Models;

    public class MyAdventureDbContext : IdentityDbContext
    {
        public MyAdventureDbContext(DbContextOptions<MyAdventureDbContext> options)
            : base(options)
        {
        }

        public DbSet<Route> Routes { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Route>()
                .HasOne(c => c.Category)
                .WithMany(r => r.Routes)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<Route>()
               .HasOne(c => c.Season)
               .WithMany(r => r.Routes)
               .HasForeignKey(x => x.SeasonId)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
