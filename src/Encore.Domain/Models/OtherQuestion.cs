using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class OtherQuestion : Entity<OtherQuestion>
    {
        public string? Name { get; set; }
        public Guid QuestionId { get; set; }

        #region Mapping
        public Question Question { get; set; }
        #endregion

        public OtherQuestion(){}
        public OtherQuestion(string name, Guid questionId, DateTime addedData)
        {
            Name = name;
            QuestionId = questionId;
            AddedDate = addedData;
        }
    }

}
