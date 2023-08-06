using Encore.Application.Questions.Responses;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Questions.Queries
{
    public class QuestionListQuery : Query<IEnumerable<QuestionResponse>>
    {
        public string? SlugForm { get; set; }
    }
}
