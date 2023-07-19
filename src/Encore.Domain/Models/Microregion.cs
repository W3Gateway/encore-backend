using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class Microregion : Entity<Microregion>
    {
        public string Name { get; set; }
        public Guid HealthCenterId { get; set; }

        #region Mapping
        public HealthCenter HealthCenter { get; set; }
        public List<Agent> Agents { get; set; }
        public List<Person> Persons { get; set; }
        public List<Home> Homes { get; set; }
        #endregion

    }

}
