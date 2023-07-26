using AutoMapper;
using Encore.Application.Visits.Queries;
using Encore.Application.Visits.Responses;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Visits.Handlers
{
    public class GetVisitListQueryHandler : IRequestHandler<GetVisitListQuery, IEnumerable<VisitResponse>>
    {
        private readonly IVisitRepository _VisitRepository;
        private readonly IMapper _mapper;

        public GetVisitListQueryHandler(IVisitRepository VisitRepository,
                                       IMapper mapper)
        {
            _VisitRepository = VisitRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<VisitResponse>> Handle(GetVisitListQuery request, CancellationToken cancellationToken)
        {
            var entity = await _VisitRepository.Include().ToListAsync();
            if (entity is null)
                return null;

            return _mapper.Map<IEnumerable<VisitResponse>>(entity);
        }
    }
}
