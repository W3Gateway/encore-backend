using Encore.Domain.Core.Models;
using Encore.Domain.Homes;

namespace Encore.Domain.Models
{
    public class Microregion : Entity<Microregion>
    {
        public string Name { get; set; }
        public Guid HealthCenterId { get; set; }

        #region Mapping
        public HealthCenter HealthCenter { get; set; }
        public IEnumerable<Agent> Agents { get; set; }
        public IEnumerable<Person> Persons { get; set; }
        public IEnumerable<Home> Homes { get; set; }
        public IEnumerable<Visit> Visits { get; set; }
        #endregion

    }

}
