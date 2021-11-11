using AutoMapper;
using MyAdventure.Data.Models;
using MyAdventure.Services.Routes.Models;

namespace MyAdventure.Services.Infrastructure
{

    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<Route, RouteServiceLastest>();
        }
    }
}
