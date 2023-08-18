using AutoMapper;
using Encore.Application.Homes.Commands;
using Encore.Application.Homes.Responses;
using Encore.Domain.Models;

namespace Encore.Application.Homes
{
    public class HomeMappingProfile : Profile
    {
        public HomeMappingProfile()
        {
            CreateMap<Home, HomeResponse>()
                .ForMember(dest => dest.ResponsibleDocument, opt => opt.MapFrom(src => src.Persons.FirstOrDefault(p => p.IsHeadFamily).Document));
            CreateMap<Person, HomePersonResponse>();
            CreateMap<HomeUpdateCommand, Home>();
            CreateMap<HomeCreateCommand, Home>();
        }
    }
}
