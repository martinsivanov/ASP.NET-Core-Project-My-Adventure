namespace MyAdventure.Infrastructure
{
    using AutoMapper;
    using MyAdventure.Data.Models;
    using MyAdventure.Models.Home;
    using MyAdventure.Models.Routes;
    using MyAdventure.Services.Routes.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Route, RouteIndexViewModel>();
            this.CreateMap<RouteDetailsServiceModel, RouteFormModel>();


            this.CreateMap<Route, RouteDetailsServiceModel>()
                .ForMember(x => x.UserId, cfg => cfg.MapFrom(c => c.Guide.UserId));
        }
    }
}
