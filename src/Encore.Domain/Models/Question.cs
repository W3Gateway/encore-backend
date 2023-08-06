using Encore.Domain.Core.Models;
using Encore.Domain.Enum;

namespace Encore.Domain.Models
{
    public class Question : Entity<Question>
    {
        public string Name { get; set; }
        public int ResponseType { get; set; }
        public bool Mandatory { get; set; }
        public Guid? FormId { get; set; }
        public string SlugProperty { get; set; }
        public int? Order { get; set; }

        #region Mapping
        public IEnumerable<OtherQuestion>? OtherQuestions { get; set; }
        public IEnumerable<OtherQuestion>? OtherSubQuestions { get; set; }       
        public IEnumerable<QuestionAnswer>? Answers { get; set; }
        public Form? Form { get; set; }
        #endregion

        public Question(){}
        public Question(string name, int responseType, bool mandatory, DateTime data, Form? form, string slugProperty, int? order)
        {
            Name = name;
            ResponseType = responseType;
            Mandatory = mandatory;
            AddedDate = data;
            Form = form;
            SlugProperty = slugProperty;
            Order = order;
        }
    }

}
