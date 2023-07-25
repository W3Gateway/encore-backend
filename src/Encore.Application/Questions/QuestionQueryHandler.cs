using AutoMapper;
using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Questions
{
    public class QuestionListQueryHandler : IRequestHandler<QuestionListQuery, IEnumerable<QuestionResponse>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IOtherQuestionRepository _otherQuestionRepositository;
        private readonly IMapper _mapper;

        public QuestionListQueryHandler(IQuestionRepository questionRepository, 
                                        IOtherQuestionRepository otherQuestionRepository,
                                        IMapper mapper)
        {
            _questionRepository = questionRepository;
            _otherQuestionRepositository = otherQuestionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionResponse>> Handle(QuestionListQuery request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.Include(x => x.OtherQuestions).ToListAsync(cancellationToken);

            if (questions is null)
                return null;

            var response = _mapper.Map<IEnumerable<QuestionResponse>>(questions);

            return response;
        }
    }
}
