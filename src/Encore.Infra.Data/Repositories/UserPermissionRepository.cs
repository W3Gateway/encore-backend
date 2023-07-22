using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using Encore.Infra.Data.Context;

namespace Encore.Infra.Data.Repositories
{
    public class UserPermissionRepository : Repository<UserPermission>, IUserPermissionRepository
    {
        public UserPermissionRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
