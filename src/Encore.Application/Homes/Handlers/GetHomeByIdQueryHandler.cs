using AutoMapper;
using Encore.Application.Homes.Queries;
using Encore.Application.Homes.Responses;
using Encore.Application.Persons.Responses;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Homes.Handlers
{
    public class GetHomeByIdQueryHandler : IRequestHandler<GetHomeByIdQuery, HomeResponse>
    {
        private readonly IHomeRepository _homeRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetHomeByIdQueryHandler(IHomeRepository homeRepository,
                                       IPersonRepository personRepository,
                                       IMapper mapper)
        {
            _homeRepository = homeRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<HomeResponse> Handle(GetHomeByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _homeRepository.GetByIdAsync(request.Id);
            if (entity is null)
                return null;
            
            var result = _mapper.Map<HomeResponse>(entity);

            var headFamily = _personRepository.Include().FirstOrDefaultAsync(p => p.HomeId == entity.Id && p.IsHeadFamily);
            if (headFamily is not null)
                result.HeadFamily = _mapper.Map<HomePersonResponse>(headFamily);

            return result;
        }
    }
}
