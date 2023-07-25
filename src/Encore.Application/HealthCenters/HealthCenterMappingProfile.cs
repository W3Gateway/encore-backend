using AutoMapper;
using Encore.Application.HealthCenters.Response;
using Encore.Domain.Models;

namespace Encore.Application.HealthCenters
{
    public class HealthCenterMappingProfile : Profile
    {
        public HealthCenterMappingProfile()
        {
            CreateMap<HealthCenter, HealthCenterAgentResponse>();
        }
    }
}
