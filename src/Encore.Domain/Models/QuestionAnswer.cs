using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class QuestionAnswer : Entity<QuestionAnswer>
    {
        public Question Question { get; set; }
        public Guid QuestionId { get; set; }
        public string? Response { get; set; }
        public Guid VisitId { get; set; }
        public Visit Visit { get; set; }
    }

}
