using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class OtherQuestion : Entity<OtherQuestion>
    {
        public string? Name { get; set; }
        public Guid QuestionId { get; set; }
        public Guid? SubQuestionId { get; set; }

        #region Mapping
        public Question Question { get; set; }
        public Question? SubQuestion { get; set; }
        #endregion

        public OtherQuestion(){}
        public OtherQuestion(string name, Guid questionId, DateTime addedData, Guid? subQuestionId)
        {
            Name = name;
            QuestionId = questionId;
            AddedDate = addedData;
            SubQuestionId = subQuestionId;
        }
    }

}
