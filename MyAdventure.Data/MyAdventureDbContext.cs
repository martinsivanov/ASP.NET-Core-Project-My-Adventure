﻿namespace MyAdventure.Data
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
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }


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
                .HasOne(r => r.Route)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.RouteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Reservation>()
                .HasOne(x => x.Guide)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.GuideId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Reservation>()
                .HasOne(x => x.User)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Review>()
                .HasOne(x => x.Route)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.RouteId)
                .OnDelete(DeleteBehavior.Restrict);
                

            base.OnModelCreating(builder);
        }
    }
}
