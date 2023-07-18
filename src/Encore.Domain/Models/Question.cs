using Encore.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Encore.Domain.Models
{
    public class Question : Entity<Question>
    {
        public string? Name { get; set; }
        public int ResponseType { get; set; }
        public bool Mandatory { get; set; }
        public DbSet<ChecklistQuestion>? ChecklistQuestions { get; set; }
        public DbSet<QuestionAnswer>? QuestionAnswers { get; set; }

        public Question(string name, int responseType, bool mandatory)
        {
            Name = name;
            ResponseType = responseType;
            Mandatory = mandatory;
        }
    }

}
