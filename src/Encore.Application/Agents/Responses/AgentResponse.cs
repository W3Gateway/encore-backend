using Encore.Application.HealthCenters.Response;
using Encore.Application.Microregions;

namespace Encore.Application.Agents.Responses
{
    public class AgentResponse
    {
        public HealthCenterAgentResponse HealthCenter { get; set; }
        public MicroregionResponse Microregion { get; set; }
    }
}
