using Encore.Application.Agents.Responses;
using Encore.Application.Agents.Search;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Agents.Queries
{
    public class GetListAgentQuery : QueryList<IEnumerable<AgentResponse>, AgentSearch>
    {
    }
}
