using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class Visit : Entity<Visit>
    {
        public Guid AgentId { get; set; }
        public Guid PersonId { get; set; }

        #region Mapping
        public Person Person { get; set; }
        public Agent Agent { get; set; }
        public List<QuestionAnswer> Answers { get; set; }
        #endregion
    }

}
