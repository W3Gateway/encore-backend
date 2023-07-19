using Encore.Domain.Interfaces.CrossCutting;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using MediatR;

namespace Encore.Application.Auth
{
    public class QuestionListQueryHandler : IRequestHandler<QuestionListQuery, List<QuestionResponse>>
    {
        private readonly IQuestionRepository _questionRepository;

        private readonly IEntityToDtoMapper<Question, QuestionResponse> _mapper;

        public QuestionListQueryHandler(IQuestionRepository questionRepository, IEntityToDtoMapper<Question, QuestionResponse> mapper) 
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<List<QuestionResponse>> Handle(QuestionListQuery request, CancellationToken cancellationToken)
        {
            //var questions = await _questionRepository.GetAsync();
            var questions = new List<Question>();
            questions.Add(new Question("1", 1, false));
            questions.Add(new Question("2", 2, false));
            questions.Add(new Question("3", 3, true));

            if (questions is null)
            {
                return null;
            }

            var dtoList = _mapper.MapList(questions);

            return dtoList;
        }
    }
}
