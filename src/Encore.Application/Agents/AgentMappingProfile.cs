using AutoMapper;
using Encore.Application.Agents.Responses;
using Encore.Domain.Models;

namespace Encore.Application.Agents
{
    public class HealthCenterMappingProfile : Profile
    {
        public HealthCenterMappingProfile()
        {
            CreateMap<Agent, AgentResponse>();
            CreateMap<HealthCenter, AgentHealthCenterResponse>();
            CreateMap<Microregion, AgentMicroregionResponse>();
        }
    }
}
