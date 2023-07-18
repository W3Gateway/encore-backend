using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class UserPermission : Entity<UserPermission>
    {
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }
    }

}
