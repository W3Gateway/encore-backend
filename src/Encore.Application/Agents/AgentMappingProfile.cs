using AutoMapper;
using Encore.Application.Agents.Responses;
using Encore.Domain.Models;

namespace Encore.Application.Agents
{
    public class AgentMappingProfile : Profile
    {
        public AgentMappingProfile()
        {
            CreateMap<Agent, AgentResponse>();
        }
    }
}
