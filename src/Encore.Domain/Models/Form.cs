using Encore.Domain.Core.Models;
using Encore.Domain.Enum;

namespace Encore.Domain.Models
{
    public class Form : Entity<Form>
    {
        public EFormType Slug { get; set; }

        public string Title { get; set; }

        #region Mapping
        public IEnumerable<Question> Questions { get; set; }
        #endregion

        public Form() { }
        public Form(EFormType slug, string title)
        {
            Slug = slug;
            Title = title;
        }
    }

}
