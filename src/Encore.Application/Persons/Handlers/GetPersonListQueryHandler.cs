using AutoMapper;
using Encore.Application.Persons.Queries;
using Encore.Application.Persons.Responses;
using Encore.Application.Persons.Search;
using Encore.Domain.Interfaces.CrossCutting;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace Encore.Application.Persons.Handlers
{
    public class GetPersonListQueryHandler : IRequestHandler<GetPersonListQuery, IEnumerable<PersonResponse>?>
    {
        private readonly IPersonRepository _personRepository;
        private readonly ISearchService<Person> _searchService;
        private readonly IMapper _mapper;

        public GetPersonListQueryHandler(IPersonRepository personRepository,
                                        ISearchService<Person> searchService,
                                        IMapper mapper)
        {
            _personRepository = personRepository;
            _searchService = searchService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonResponse>?> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            var entities = _personRepository.Include();
            var predicate = ApplyFilters(request.Search);
            var list = await entities.Where(predicate)
                                    .OrderBy(p => p.Name)
                                    .Skip((request.Page - 1) * request.PageSize)
                                    .Take(request.PageSize)
                                    .ToListAsync(cancellationToken: cancellationToken);

            if (list.IsNullOrEmpty())
                return null;

            return _mapper.Map<IEnumerable<PersonResponse>>(list);
        }

        public Expression<Func<Person, bool>> ApplyFilters(PersonSearch filter)
        {
            if (filter is null)
            {
                return x => true;
            }

            Expression<Func<Person, bool>> predicate = x => true;

            if (!filter.Name.IsNullOrEmpty())
            {
                predicate = _searchService.AndAlso(predicate, x => x.Name.Contains(filter.Name));
            }

            if (!filter.Document.IsNullOrEmpty())
            {
                predicate = _searchService.AndAlso(predicate, x => x.Document.Contains(filter.Document));
            }

            return predicate;
        }
    }
}
