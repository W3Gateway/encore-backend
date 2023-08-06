using AutoMapper;
using Encore.Application.Questions.Queries;
using Encore.Application.Questions.Responses;
using Encore.Domain.Core.Extensions;
using Encore.Domain.Enum;
using Encore.Domain.Interfaces.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Encore.Application.Questions.Handlers
{
    public class QuestionListQueryHandler : IRequestHandler<QuestionListQuery, IEnumerable<QuestionResponse>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionListQueryHandler(IQuestionRepository questionRepository,
                                        IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionResponse>> Handle(QuestionListQuery request, CancellationToken cancellationToken)
        {
            var value = (EFormType)Enum.Parse(typeof(EFormType), request.SlugForm);

            var questions = await _questionRepository.Include(q => q.Form)
                .Where(q => q.Form.Slug.Equals(value))
                .Include(q => q.OtherQuestions.OrderBy(oq => oq.Name))
                .ThenInclude(oq => oq.SubQuestion)
                .ThenInclude(sq => sq.OtherQuestions.OrderBy(oq => oq.Name))
                .OrderBy(q => q.Order)
                .ToListAsync(cancellationToken);


            if (questions is null)
                return null;

            var response = _mapper.Map<IEnumerable<QuestionResponse>>(questions);

            return response;
        }
    }
}