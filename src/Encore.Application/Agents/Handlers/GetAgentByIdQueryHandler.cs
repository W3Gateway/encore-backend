using AutoMapper;
using Encore.Application.Agents.Queries;
using Encore.Application.Agents.Responses;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Agents.Handlers
{
    public class GetAgentByUserIdQueryHandler : IRequestHandler<GetAgentByUserIdQuery, AgentResponse>
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;

        public GetAgentByUserIdQueryHandler(IAgentRepository agentRepository,
                                       IMapper mapper)
        {
            _agentRepository = agentRepository;
            _mapper = mapper;
        }
        public async Task<AgentResponse> Handle(GetAgentByUserIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _agentRepository.Include().Include(a => a.Microregion).Include(a => a.HealthCenter).FirstOrDefaultAsync(a => a.UserId.Equals(request.UserId));
            if (entity is null)
                return null;

            return _mapper.Map<AgentResponse>(entity);
        }
    }
}
