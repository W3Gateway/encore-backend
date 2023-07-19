using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class Agent : Entity<Agent>
    {
        public Guid UserId { get; set; }
        public Guid HealthCenterId { get; set; }
        public Guid MicroregionId { get; set; }

        #region Mapping
        public User User { get; set; }
        public HealthCenter HealthCenter { get; set; }
        public Microregion Microregion { get; set; }
        #endregion
    }

}
