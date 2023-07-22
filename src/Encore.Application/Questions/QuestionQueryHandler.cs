using Encore.Domain.Interfaces.CrossCutting;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using MediatR;

namespace Encore.Application.Auth
{
    public class QuestionListQueryHandler : IRequestHandler<QuestionListQuery, List<QuestionResponse>?>
    {
        private readonly IQuestionRepository _questionRepository;

        private readonly IEntityToDtoMapper<Question, QuestionResponse> _mapper;

        public QuestionListQueryHandler(IQuestionRepository questionRepository, IEntityToDtoMapper<Question, QuestionResponse> mapper) 
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<List<QuestionResponse>?> Handle(QuestionListQuery request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.GetAsync();

            if (questions is null)
                return null;

            var dtoList = _mapper.MapList(questions);

            return dtoList;
        }
    }
}
