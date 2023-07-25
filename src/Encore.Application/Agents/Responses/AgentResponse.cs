using Encore.Domain.Core.Responses;
using Encore.Domain.Models;

namespace Encore.Application.Agents.Responses
{
    public class AgentResponse : Response<AgentResponse>
    {
        public HealthCenter HealthCenter { get; set; }
        public Microregion Microregion { get; set; }

        public AgentResponse(HealthCenter healthCenter, Microregion microregion)
        {
            HealthCenter = healthCenter;
            Microregion = microregion;
        }
    }
}
