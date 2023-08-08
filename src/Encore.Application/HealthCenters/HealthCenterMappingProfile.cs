using AutoMapper;
using Encore.Application.Agents.Responses;
using Encore.Application.HealthCenters.Responses;
using Encore.Domain.Models;

namespace Encore.Application.HealthCenters
{
    public class HealthCenterMappingProfile : Profile
    {
        public HealthCenterMappingProfile()
        {
            CreateMap<HealthCenter, HealthCenterAgentResponse>();
            CreateMap<HealthCenter, AgentHealthCenterResponse>();
            CreateMap<Microregion, AgentMicroregionResponse>();
        }
    }
}
