using AutoMapper;
using Encore.Application.Homes.Responses;
using Encore.Domain.Homes;

namespace Encore.Application.Homes
{
    public class HomeMappingProfile : Profile
    {
        public HomeMappingProfile()
        {
            CreateMap<Home, HomeResponse>()
                .ForMember(dest => dest.HeadFamily, opt => opt.MapFrom(src => src.Persons));
        }
    }
}
