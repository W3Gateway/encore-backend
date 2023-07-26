using Encore.Application.Agents.Responses;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Agents.Queries
{
    public class GetAgentByUserIdQuery : Query<AgentResponse>
    {
        public Guid UserId { get; set; }

        public GetAgentByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
