using AutoMapper;
using Encore.Application.Homes.Responses;
using Encore.Domain.Homes;
using Encore.Domain.Models;

namespace Encore.Application.Homes
{
    public class HomeMappingProfile : Profile
    {
        public HomeMappingProfile()
        {
            CreateMap<Home, HomeResponse>()
                .ForMember(dest => dest.HeadFamily, opt => opt.MapFrom(src => src.Persons.FirstOrDefault(p => p.IsHeadFamily)));
            CreateMap<Person, HomePersonResponse>();
            CreateMap<Microregion, HomeMicroregionResponse>();
        }
    }
}
