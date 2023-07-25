using AutoMapper;
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
