using AutoMapper;
using Encore.Application.Homes.Queries;
using Encore.Application.Homes.Responses;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

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
            var entity = await _homeRepository.Include().Where(c => c.MicroregionId == request.MicroregionId).ToListAsync();
            if (entity is null)
                return null;

            return _mapper.Map<IEnumerable<HomeResponse>>(entity);
        }
    }
}
