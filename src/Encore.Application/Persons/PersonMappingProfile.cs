using AutoMapper;
using Encore.Application.Persons.Commands;
using Encore.Application.Persons.Responses;
using Encore.Domain.Models;

namespace Encore.Application.Persons
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonResponse>()
                .ForMember(dest => dest.HomeId, opt => opt.MapFrom(src => src.HomeId));
            CreateMap<Microregion, PersonMicroregionResponse>();

            CreateMap<PersonCreateCommand, Person>();
        }
    }
}
