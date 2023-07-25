using Encore.Domain.Core.Models;
using Encore.Domain.Homes;

namespace Encore.Domain.Models
{
    public class Visit : Entity<Visit>
    {
        public Guid AgentId { get; set; }
        public Guid PersonId { get; set; }
        public Guid HomeId { get; set; }
        public Guid MicroregionId { get; set; }

        #region Mapping
        public Person Person { get; set; }
        public Agent Agent { get; set; }
        public Home Home { get; set; }
        public Microregion Microregion { get; set; }
        public IEnumerable<QuestionAnswer> Answers { get; set; }
        #endregion
    }

}
