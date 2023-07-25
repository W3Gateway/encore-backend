using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class Question : Entity<Question>
    {
        public string Name { get; set; }
        public int ResponseType { get; set; }
        public bool Mandatory { get; set; }

        #region Mapping
        public IEnumerable<OtherQuestion>? OtherQuestions { get; set; }
        public IEnumerable<QuestionAnswer>? Answers { get; set; }
        #endregion

        public Question(){}
        public Question(string name, int responseType, bool mandatory, DateTime data)
        {
            Name = name;
            ResponseType = responseType;
            Mandatory = mandatory;
            AddedDate = data;
        }
    }

}
