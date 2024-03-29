﻿namespace MyAdventure.Infrastructure
{
    using AutoMapper;
    using MyAdventure.Data.Models;
    using MyAdventure.Models.BlogPosts;
    using MyAdventure.Models.Home;
    using MyAdventure.Models.Routes;
    using MyAdventure.Services.BlogPosts.Models;
    using MyAdventure.Services.Routes.Models;
    using System.Globalization;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Route, RouteIndexViewModel>();
            this.CreateMap<RouteDetailsServiceModel, RouteFormModel>()
                .ForMember(x => x.DepartureTime, opt => opt.MapFrom(src => src.DepartureTime.ToString("f", CultureInfo.InvariantCulture)));


            this.CreateMap<Route, RouteDetailsServiceModel>()
                .ForMember(x => x.UserId, cfg => cfg.MapFrom(c => c.Guide.UserId));

            this.CreateMap<BlogPostFormModel, BlogPostServiceModel>();
        }
    }
}
