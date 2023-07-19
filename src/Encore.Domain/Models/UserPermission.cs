using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class UserPermission : Entity<UserPermission>
    {
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }

        #region Mapping
        public User User { get; set; }
        public Permission Permission { get; set; }
        #endregion
    }

}
