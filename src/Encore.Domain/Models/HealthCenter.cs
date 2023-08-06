using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class HealthCenter : Entity<HealthCenter>
    {
        public string Name { get; set; }
        public string Cnes { get; set; }
        public Guid AccountableId { get; set; }
        public Guid AddressId { get; set; }

        #region Mapping
        public User Accountable { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Agent> Agents { get; set; }
        public IEnumerable<Microregion> Microregions { get; set; }
        #endregion
    }

}
