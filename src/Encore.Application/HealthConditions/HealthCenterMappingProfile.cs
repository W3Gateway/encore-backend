using AutoMapper;
using Encore.Domain.Models;

namespace Encore.Application.HealthConditions
{
    public class HealthConditionMappingProfile : Profile
    {
        public HealthConditionMappingProfile()
        {
            CreateMap<HealthConditionCommand, HealthCondition>();
        }
    }
}
