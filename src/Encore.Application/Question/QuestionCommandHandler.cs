using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.CrossCutting;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using MediatR;

namespace Encore.Application.Auth
{
    public class QuestionListCommandHandler : CommandHandler, IRequestHandler<QuestionListCommand, Response<QuestionListResponse>>
    {
        private readonly IQuestionRepository _questionRepository;

        private readonly IEntityToDtoMapper<Question, QuestionResponse> _mapper;

        public QuestionListCommandHandler(IQuestionRepository questionRepository, IEntityToDtoMapper<Question, QuestionResponse> mapper) 
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Response<QuestionListResponse>> Handle(QuestionListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //var questions = await _questionRepository.GetAsync();
                var questions = new List<Question>()
                {
                    new Question("1", 1, false),
                    new Question("2", 2, false),
                    new Question("3", 3, true)
                };
                if (questions is null)
                {
                    AddError("Questões não encontradas");
                    return Fail<QuestionListResponse>(ValidationResult);
                }

                var dtoList = _mapper.MapList(questions);

                return new QuestionListResponse(dtoList);
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar autenticação");
                return Fail<QuestionListResponse>(ValidationResult);
            }
        }
    }
}
