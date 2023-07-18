using Encore.Domain.Core.Responses;

namespace Encore.Application.Auth
{
    public class QuestionListResponse : Response<QuestionListResponse>
    {
        public IList<QuestionResponse> QuestionsResponses { get; set; }

        public QuestionListResponse(IList<QuestionResponse> questionsResponses)
        {
            QuestionsResponses = questionsResponses;
        }
    }
}
