using Encore.Domain.Core.Models;
using Encore.Domain.ValueObjects;

namespace Encore.Domain.Models
{
    public class HealthCenter : Entity<HealthCenter>
    {
        public string Name { get; set; }
        public string Cnes { get; set; }
        public Adderess Adderess { get; set; }
        public Guid AccountableId { get; set; }
    }

}
