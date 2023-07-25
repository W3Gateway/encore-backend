using AutoMapper;
using Encore.Application.Agents.Queries;
using Encore.Application.Agents.Responses;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.Data;
using MediatR;
using System.Data.Entity;

namespace Encore.Application.Agents.Handlers
{
    public class GetAgentByUserIdQueryHandler : IRequestHandler<GetAgentByUserIdQuery, Response<AgentResponse>>
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;

        public GetAgentByUserIdQueryHandler(IAgentRepository agentRepository,
                                       IMapper mapper)
        {
            _agentRepository = agentRepository;
            _mapper = mapper;
        }
        public async Task<Response<AgentResponse>> Handle(GetAgentByUserIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _agentRepository.Include().FirstOrDefaultAsync(a => a.UserId.Equals(request.UserId));
            if (entity is null)
                return null;

            var result = _mapper.Map<AgentResponse>(entity);

            return result;
        }
    }
}
