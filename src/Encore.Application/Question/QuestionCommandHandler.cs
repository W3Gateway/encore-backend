using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;
using Encore.Domain.Interfaces.CrossCutting;
using Encore.Domain.Interfaces.Data;
using Encore.Infra.CrossCutting.Services;
using Encore.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Auth
{
    public class QuestionCommandHandler : CommandHandler, IRequestHandler<QuestionCommand, Response<QuestionResponse>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionService _questionService;
        
        public QuestionCommandHandler(IQuestionRepository questionRepository) 
        {
            _questionRepository = questionRepository;
        }

        public async Task<Response<QuestionResponse>> Handle(QuestionCommand request)
        {
            try
            {
                var questions = await _questionService.GetAll();
                if (questions is null)
                {
                    AddError("Questões não encontradas");
                    return Fail<QuestionResponse>(ValidationResult);
                }

                return new QuestionResponse(questions);
            }
            catch (Exception ex)
            {
                AddError("Erro ao realizar autenticação");
                return Fail<QuestionResponse>(ValidationResult);
            }
        }
    }
}
