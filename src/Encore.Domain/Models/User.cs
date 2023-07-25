using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class User : Entity<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? ContactNumber { get; set; }
        public string? Cns { get; set; }

        #region Mapping
        public IEnumerable<Agent> Agents { get; set; }
        public HealthCenter HealthCenter { get; set; }
        public IEnumerable<UserPermission> Permissions { get; set; }
        #endregion
    }

}
