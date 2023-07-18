using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class QuestionAnswer : Entity<QuestionAnswer>
    {
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public string? Response { get; set; }

        //public Visit Visit { get; set; };

        public QuestionAnswer(Question Question)
        {
            this.Question = Question;
            //this.Visit = Visit;
        }
    }

}
