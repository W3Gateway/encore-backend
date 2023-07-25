using AutoMapper;
using Encore.Application.Persons.Queries;
using Encore.Application.Persons.Responses;
using Encore.Domain.Interfaces.Data;
using MediatR;

namespace Encore.Application.Persons.Handlers
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonResponse?>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetPersonByIdQueryHandler(IPersonRepository personRepository,
                                        IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<PersonResponse?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _personRepository.GetByIdAsync(request.Id);
            if (entity is null)
                return null;

            return _mapper.Map<PersonResponse>(entity);
        }
    }
}
