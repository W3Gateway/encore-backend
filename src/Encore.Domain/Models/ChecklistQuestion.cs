using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class ChecklistQuestion : Entity<ChecklistQuestion>
    {
        public string? Name { get; set; }
        public Question Question { get; set; }
        public Guid QuestionId { get; set; }
    }

}
