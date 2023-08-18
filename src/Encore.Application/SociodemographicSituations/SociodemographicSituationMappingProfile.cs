using AutoMapper;
using Encore.Domain.Models;

namespace Encore.Application.SociodemographicSituations
{
    public class SociodemographicSituationMappingProfile : Profile
    {
        public SociodemographicSituationMappingProfile()
        {
            CreateMap<SociodemographicSituationCommand, SociodemographicSituation>();
        }
    }
}
