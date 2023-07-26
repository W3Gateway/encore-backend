using AutoMapper;
using Encore.Application.Homes.Queries;
using Encore.Application.Homes.Responses;
using Encore.Domain.Core.Extensions;
using Encore.Domain.Homes;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Encore.Application.Homes.Handlers
{
    public class GetHomeListQueryHandler : IRequestHandler<GetHomeListQuery, IEnumerable<HomeResponse>>
    {
        private readonly IHomeRepository _homeRepository;
        private readonly IMapper _mapper;

        public GetHomeListQueryHandler(IHomeRepository homeRepository,
                                        IMapper mapper)
        {
            _homeRepository = homeRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<HomeResponse>> Handle(GetHomeListQuery request, CancellationToken cancellationToken)
        {
            var entities = _homeRepository.Include();
            var list = await ApplyFilter(request, entities).Include(h => h.Microregion)
                                    .Include(h => h.Persons)
                                    .OrderBy(h => h.Address.Number)
                                    .Skip((request.Page - 1) * request.PageSize)
                                    .Take(request.PageSize)
                                    .ToListAsync(cancellationToken: cancellationToken);

            if (list.IsNullOrEmpty())
                return null;

            return _mapper.Map<IEnumerable<HomeResponse>>(list);
        }

        private static IQueryable<Home> ApplyFilter(GetHomeListQuery request, IQueryable<Home> entities)
        {
            if (request.Search.IsNullOrEmpty())
                return entities;

            var filter = request.Search.ToLowerTrim();

            return entities.Where(c => c.MicroregionId == request.MicroregionId)
                                .Where(x => x.Address.Neighborhood.ToLower().Trim().Contains(filter) ||
                                        x.Address.Street.ToLower().Trim().Contains(filter));
        }
    }
}
