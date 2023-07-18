using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class ChecklistQuestion : Entity<ChecklistQuestion>
    {
        public string? Name { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }

        public ChecklistQuestion(Question Question)
        {
            this.Question = Question;
        }
    }

}
