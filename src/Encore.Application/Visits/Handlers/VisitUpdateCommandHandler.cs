using AutoMapper;
using Encore.Application.Visits.Commands;
using Encore.Application.Visits.Responses;
using Encore.Domain.Core.Data;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Visits.Handlers
{
    public class VisitUpdateCommandHandler : CommandHandler, IRequestHandler<VisitUpdateCommand, Response<VisitResponse>>
    {
        private readonly IMicroregionRepository _microregionRepository;
        private readonly IAgentRepository _agentRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IHomeRepository _homeRepository;
        private readonly IVisitRepository _visitRepository;
        private readonly IMapper _mapper;

        public VisitUpdateCommandHandler(IMicroregionRepository microregionRepository,
                                        IVisitRepository visitRepository,
                                        IMapper mapper) : base(visitRepository.UnitOfWork)
        {
            _microregionRepository = microregionRepository;
            _visitRepository = visitRepository;
            _mapper = mapper;

        }

        public async Task<Response<VisitResponse>> Handle(VisitUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _visitRepository.GetByIdAsync(request.Id, cancellationToken);
                if (entity is null)
                {
                    AddError("Não foi encontrado o domicílio informado na base de dados");
                    return Fail<VisitResponse>(ValidationResult);
                }

                var microregion = await _microregionRepository.GetByIdAsync(request.MicroregionId);
                if (microregion is null)
                {
                    AddError("Não foi encontrada a microárea informada na base de dados");
                    return Fail<VisitResponse>(ValidationResult);
                }

                var person = await _personRepository.GetByIdAsync(request.PersonId);
                if (person is null)
                {
                    AddError("Não foi encontrado o indivíduo informado na base de dados");
                    return Fail<VisitResponse>(ValidationResult);
                }

                var home = await _homeRepository.GetByIdAsync(request.HomeId);
                if (home is null)
                {
                    AddError("Não foi encontrado o domicílio informado na base de dados");
                    return Fail<VisitResponse>(ValidationResult);
                }

                var agent = await _agentRepository.GetByIdAsync(request.AgentId);
                if (agent is null)
                {
                    AddError("Não foi encontrado o agente informado na base de dados");
                    return Fail<VisitResponse>(ValidationResult);
                }

                var answers = _mapper.Map<IEnumerable<QuestionAnswer>>(request.Answers);

                entity.CopyProperties(request.AgentId, request.PersonId, request.HomeId, request.MicroregionId, answers);
                entity = await _visitRepository.UpdateAsync(entity, cancellationToken);
                await SaveAsync(cancellationToken);
                return Success(_mapper.Map<VisitResponse>(entity));
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar o cadastro de domicílio: " + ex.Message);
                return Fail<VisitResponse>(ValidationResult);
            }
        }
    }
}
