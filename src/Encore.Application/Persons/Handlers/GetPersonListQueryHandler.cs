using AutoMapper;
using Encore.Application.Persons.Queries;
using Encore.Application.Persons.Responses;
using Encore.Domain.Core.Extensions;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Encore.Application.Persons.Handlers
{
    public class GetPersonListQueryHandler : IRequestHandler<GetPersonListQuery, IEnumerable<PersonResponse>?>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetPersonListQueryHandler(IPersonRepository personRepository,
                                        IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonResponse>?> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            var entities = _personRepository.Include();
            var list = await ApplyFilter(request, entities).OrderBy(p => p.Name)
                                    .Skip((request.Page - 1) * request.PageSize)
                                    .Take(request.PageSize)
                                    .ToListAsync(cancellationToken: cancellationToken);

            if (list.IsNullOrEmpty())
                return null;

            return _mapper.Map<IEnumerable<PersonResponse>>(list);
        }

        private static IQueryable<Person> ApplyFilter(GetPersonListQuery request, IQueryable<Person> entities)
        {
            if (!request.HomeId.Equals(Guid.Empty))
                entities = entities.Where(p => p.HomeId.Equals(request.HomeId));

            if (!request.MicroregionId.Equals(Guid.Empty))
                entities = entities.Where(p => p.MicroregionId.Equals(request.MicroregionId));

            if (request.Search.IsNullOrEmpty())
                return entities;

            var filter = request.Search.ToLowerTrim();

            return entities.Where(x => x.Name.ToLower().Trim().Contains(filter) ||
                                    x.Document.ToLower().Trim().Contains(filter));
        }
    }
}
