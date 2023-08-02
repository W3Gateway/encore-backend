using AutoMapper;
using Encore.Application.Microregions.Responses;
using Encore.Domain.Models;

namespace Encore.Application.Microregions
{
    public class MicroregionMappingProfile : Profile
    {
        public MicroregionMappingProfile()
        {
            CreateMap<Microregion, MicroregionResponse>();
        }
    }
}
