using Encore.Application.Questions.Responses;
using Encore.Domain.Enum;

namespace Encore.Application.Forms.Responses
{
    public class FormResponse
    {
        public string Title { get; set; }
        public IEnumerable<QuestionResponse> Questions { get; set; }
    }
}
