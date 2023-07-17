using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class Microregion : Entity<Microregion>
    {
        public string Name { get; set; }
        public Guid HealthCenterId { get; set; }

    }

}
