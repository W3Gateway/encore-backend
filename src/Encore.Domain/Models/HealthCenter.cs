using Encore.Domain.Core.Models;
using Encore.Domain.ValueObjects;

namespace Encore.Domain.Models
{
    public class HealthCenter : Entity<HealthCenter>
    {
        public string Name { get; set; }
        public string Cnes { get; set; }
        public Address Address { get; set; }
        public Guid AccountableId { get; set; }

        #region Mapping
        public IEnumerable<Agent> Agents { get; set; }
        public User Accountable { get; set; }
        public IEnumerable<Microregion> Microregions { get; set; }
        #endregion
    }

}
