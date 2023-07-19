using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class Permission : Entity<Permission>
    {
        public string Name { get; set; }

        #region Mapping
        public List<UserPermission> Users { get; set; }
        #endregion
    }

}
