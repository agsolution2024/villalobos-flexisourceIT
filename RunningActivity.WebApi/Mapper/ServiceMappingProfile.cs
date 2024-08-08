
using AutoMapper;
using Microsoft.Identity.Client;
using RunningActivity.Domain.Contracts;
using RunningActivity.Infrastructure.DBContext;
using RunningActivity.Infrastructure.Model;
using RunningActivity.Infrastructure.Repository;
using Unity;
using Unity.Lifetime;
using static System.Collections.Specialized.BitVector32;


namespace RunningActivity.WebApi.Mapper
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            //create map for domain.entity and appservice.dto
            CreateMap<UserProfileEntities, UserProfileDto>().ReverseMap();
            CreateMap<ActivityEntities, ActivityDto>().ReverseMap();


        }
    }
}
