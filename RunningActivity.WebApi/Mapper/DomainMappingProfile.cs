
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
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
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<UserProfileEntities, UserProfile>().ReverseMap();
            CreateMap<ActivityEntities, Activities>().ReverseMap();

        }
    }
}
