using AutoMapper;
using Encore.Application.Visits.Queries;
using Encore.Application.Visits.Responses;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Visits.Handlers
{
    public class GetVisitByIdQueryHandler : IRequestHandler<GetVisitByIdQuery, VisitResponse>
    {
        private readonly IVisitRepository _VisitRepository;
        private readonly IMapper _mapper;

        public GetVisitByIdQueryHandler(IVisitRepository VisitRepository,
                                       IMapper mapper)
        {
            _VisitRepository = VisitRepository;
            _mapper = mapper;
        }
        public async Task<VisitResponse> Handle(GetVisitByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _VisitRepository.Include().Include(v => v.Answers).FirstOrDefaultAsync(v => v.Id.Equals(request.Id));
            if (entity is null)
                return null;
            
            return _mapper.Map<VisitResponse>(entity);
        }
    }
}
