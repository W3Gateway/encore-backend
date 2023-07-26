using AutoMapper;
using Encore.Application.Homes.Queries;
using Encore.Application.Homes.Responses;
using Encore.Application.Homes.Search;
using Encore.Domain.Homes;
using Encore.Domain.Interfaces.CrossCutting;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace Encore.Application.Homes.Handlers
{
    public class GetHomeListQueryHandler : IRequestHandler<GetHomeListQuery, IEnumerable<HomeResponse>>
    {
        private readonly IHomeRepository _homeRepository;
        private readonly ISearchService<Home> _searchService;
        private readonly IMapper _mapper;

        public GetHomeListQueryHandler(IHomeRepository homeRepository,
                                        ISearchService<Home> searchService,
                                        IMapper mapper)
        {
            _homeRepository = homeRepository;
            _searchService = searchService;
            _mapper = mapper;

        }
        public async Task<IEnumerable<HomeResponse>> Handle(GetHomeListQuery request, CancellationToken cancellationToken)
        {
            var entities = _homeRepository.Include();
            var predicate = ApplyFilters(request.Search);
            var list = await entities.Include(h => h.Microregion)
                                    .Include(h => h.Persons)
                                    .Where(c => c.MicroregionId == request.MicroregionId)
                                    .Where(predicate)
                                    .OrderBy(h => h.Address.Number)
                                    .Skip((request.Page - 1) * request.PageSize)
                                    .Take(request.PageSize)
                                    .ToListAsync(cancellationToken: cancellationToken);

            if (list.IsNullOrEmpty())
                return null;

            return _mapper.Map<IEnumerable<HomeResponse>>(list);
        }

        public Expression<Func<Home, bool>> ApplyFilters(HomeSearch filter)
        {
            if (filter is null)
            {
                return x => true;
            }

            Expression<Func<Home, bool>> predicate = x => true;

            if (!filter.HeadFamilyDoc.IsNullOrEmpty())
                predicate = _searchService.AndAlso(predicate, x => x.Persons.Where(p => !p.Document.Equals(filter.HeadFamilyDoc)).FirstOrDefault().IsNullOrEmpty());

            if (!filter.Neighborhood.IsNullOrEmpty())
                predicate = _searchService.AndAlso(predicate, x => x.Address.Neighborhood.ToLower().Trim().Contains(filter.Neighborhood.ToLower().Trim()));

            if (!filter.Street.IsNullOrEmpty())
                predicate = _searchService.AndAlso(predicate, x => x.Address.Street.ToLower().Trim().Contains(filter.Street.ToLower().Trim()));

            return predicate;
        }
    }
}
