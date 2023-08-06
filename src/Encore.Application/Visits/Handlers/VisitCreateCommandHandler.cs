using AutoMapper;
using Encore.Application.Visits.Commands;
using Encore.Application.Visits.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Visits.Handlers
{
    public class VisitCreateCommandHandler : CommandHandler, IRequestHandler<VisitCreateCommand, Response<VisitResponse>>
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IMicroregionRepository _microregionRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IQuestionAnswerRepository _questionAnswerRepository;
        private readonly IHomeRepository _homeRepository;        
        private readonly IVisitRepository _visitRepository;
        private readonly IMapper _mapper;

        public VisitCreateCommandHandler(IAgentRepository agentRepository,
                                        IMicroregionRepository microregionRepository,
                                        IPersonRepository personRepository,
                                        IHomeRepository homeRepository,                                        
                                        IQuestionAnswerRepository questionAnswerRepository,
                                        IVisitRepository visitRepository,
                                        IMapper mapper) : base(visitRepository.UnitOfWork)
        {
            _agentRepository = agentRepository;
            _microregionRepository = microregionRepository;
            _personRepository = personRepository;
            _questionAnswerRepository = questionAnswerRepository;
            _homeRepository = homeRepository;            
            _visitRepository = visitRepository;
            _mapper = mapper;

        }

        public async Task<Response<VisitResponse>> Handle(VisitCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var beginTransaction = BeginTransactionAsync(cancellationToken);

                var microregion = await _microregionRepository.Include().FirstOrDefaultAsync(c => c.Id == request.MicroregionId);
                if (microregion is null)
                {
                    AddError("Não foi encontrada a microárea informado na base de dados");
                    return Fail<VisitResponse>(ValidationResult);
                }

                var person = await _personRepository.Include().FirstOrDefaultAsync(c => c.Id == request.PersonId);
                if (person is null)
                {
                    AddError("Não foi encontrada o indivíduo informado na base de dados");
                    return Fail<VisitResponse>(ValidationResult);
                }
                
                var agent = await _agentRepository.Include().FirstOrDefaultAsync(c => c.Id == request.AgentId);
                if (agent is null)
                {
                    AddError("Não foi encontrada o agente informado na base de dados");
                    return Fail<VisitResponse>(ValidationResult);
                }

                var home = await _homeRepository.Include().FirstOrDefaultAsync(c => c.Id == request.HomeId);
                if (home is null)
                {
                    AddError("Não foi encontrada a microárea informado na base de dados");
                    return Fail<VisitResponse>(ValidationResult);
                }

                var answers = _mapper.Map<IEnumerable<QuestionAnswer>>(request.Answers);
                var entity = new Visit(agent.Id, person.Id, home.Id, microregion.Id, answers);
                if (!await IsValidAsync(entity))
                    return Fail<VisitResponse>(ValidationResult);

                entity = await _visitRepository.CreateAsync(entity, cancellationToken);
                answers.Select(async a => await _questionAnswerRepository.CreateAsync(a, cancellationToken));
                await CommitTransactionAsync(cancellationToken);
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
