using AutoMapper;
using Encore.Application.Agents.Queries;
using Encore.Application.Agents.Responses;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Encore.Application.Agents.Handlers
{
    public class GetListAgentQueryHandler : IRequestHandler<GetListAgentQuery, IEnumerable<AgentResponse>?>
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;

        public GetListAgentQueryHandler(IAgentRepository agentRepository,
                                        IMapper mapper)
        {
            _agentRepository = agentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AgentResponse>?> Handle(GetListAgentQuery request, CancellationToken cancellationToken)
        {
            var entities = _agentRepository.Include();
            var list = await entities.Include(a => a.Microregion)
                                    .Include(a => a.HealthCenter)
                                    .OrderBy(a => a.AddedDate)
                                    .Skip((request.Page - 1) * request.PageSize)
                                    .Take(request.PageSize)
                                    .ToListAsync();

            if (list.IsNullOrEmpty())
                return null;

            return _mapper.Map<IEnumerable<AgentResponse>>(list);
        }
    }
}
