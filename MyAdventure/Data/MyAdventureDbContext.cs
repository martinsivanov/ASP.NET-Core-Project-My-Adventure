namespace MyAdventure.Data
{
    using Microsoft.AspNetCore.Identity;
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
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

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

            builder
                .Entity<Route>()
                .HasOne(x => x.Guide)
                .WithMany(x => x.Routes)
                .HasForeignKey(x => x.GuideId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Guide>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Guide>(g => g.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Reservation>()
                .HasOne<Route>()
                .WithOne(x => x.Reservation)
                .HasForeignKey<Reservation>(r => r.RouteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Reservation>()
                .HasOne(x => x.Guide)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.GuideId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
