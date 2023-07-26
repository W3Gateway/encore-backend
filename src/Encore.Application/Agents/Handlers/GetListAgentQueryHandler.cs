using AutoMapper;
using Encore.Application.Agents.Queries;
using Encore.Application.Agents.Responses;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Encore.Domain.Interfaces.CrossCutting;
using Encore.Application.Agents.Search;

namespace Encore.Application.Agents.Handlers
{
    public class GetListAgentQueryHandler : IRequestHandler<GetListAgentQuery, IEnumerable<AgentResponse>?>
    {
        private readonly IAgentRepository _agentRepository;
        private readonly ISearchService<Agent> _searchService;
        private readonly IMapper _mapper;

        public GetListAgentQueryHandler(IAgentRepository agentRepository,
                                        ISearchService<Agent> searchService,
                                        IMapper mapper)
        {
            _agentRepository = agentRepository;
            _searchService = searchService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AgentResponse>?> Handle(GetListAgentQuery request, CancellationToken cancellationToken)
        {
            var entities = _agentRepository.Include();
            var predicate = ApplyFilters(request.Search);
            var list = await entities.Include(a => a.Microregion)
                                    .Include(a => a.HealthCenter)
                                    .Where(predicate)
                                    .OrderBy(a => a.AddedDate)
                                    .Skip((request.Page - 1) * request.PageSize)
                                    .Take(request.PageSize)
                                    .ToListAsync();

            if (list.IsNullOrEmpty())
                return null;

            return _mapper.Map<IEnumerable<AgentResponse>>(list);
        }

        public Expression<Func<Agent, bool>> ApplyFilters(AgentSearch? filter)
        {
            if (filter is null)
            {
                return x => true;
            }

            // Inicializa a expressão de filtro como uma expressão "true"
            Expression<Func<Agent, bool>> predicate = x => true;

            // Adiciona cláusulas de filtro para cada propriedade não nula do objeto Person
            if (!filter.HealthCenterName.IsNullOrEmpty())
            {
                predicate = _searchService.AndAlso(predicate, x => x.HealthCenter.Name.ToLower().Trim().Contains(filter.HealthCenterName.ToLower().Trim()));
            }

            if (!filter.MicroregionName.IsNullOrEmpty())
            {
                predicate = _searchService.AndAlso(predicate, x => x.Microregion.Name.ToLower().Trim().Contains(filter.MicroregionName.ToLower().Trim()));
            }

            // Aplica o filtro no IQueryable e retorna o resultado
            return predicate;
        }
    }
}
