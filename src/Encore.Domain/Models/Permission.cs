using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class Permission : Entity<Permission>
    {
        public string Name { get; set; }

        #region Mapping
        public IEnumerable<UserPermission> Users { get; set; }
        #endregion
    }

}
