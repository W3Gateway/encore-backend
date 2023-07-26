namespace Encore.Application.Agents.Responses
{
    public class AgentResponse
    {
        public Guid Id { get; set; }
        public AgentHealthCenterResponse? HealthCenter { get; set; }
        public AgentMicroregionResponse? Microregion { get; set; }
    }
}
