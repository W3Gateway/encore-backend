using AutoMapper;
using Encore.Application.Persons.Queries;
using Encore.Application.Persons.Responses;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var entity = await _personRepository.Include().Where(p => p.HomeId == request.HomeId).ToListAsync();
            if (entity is null)
                return null;

            return _mapper.Map<IEnumerable<PersonResponse>>(entity);
        }
    }
}
