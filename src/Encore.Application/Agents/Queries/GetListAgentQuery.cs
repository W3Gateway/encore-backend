using Encore.Application.Agents.Responses;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Agents.Queries
{
    public class GetListAgentQuery : QueryList<IEnumerable<AgentResponse>, AgentResponse>
    {
    }
}
