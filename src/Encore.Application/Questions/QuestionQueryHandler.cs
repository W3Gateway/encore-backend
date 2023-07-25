using AutoMapper;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Questions
{
    public class QuestionListQueryHandler : IRequestHandler<QuestionListQuery, IEnumerable<QuestionResponse>?>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionListQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionResponse>?> Handle(QuestionListQuery request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.Include(x => x.OtherQuestions).ToListAsync(cancellationToken);

            if (questions is null)
                return null;

            var response = _mapper.Map<IEnumerable<QuestionResponse>>(questions);

            return response;
        }
    }
}
