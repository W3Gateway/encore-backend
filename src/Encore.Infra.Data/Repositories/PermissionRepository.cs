using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using Encore.Infra.Data.Context;

namespace Encore.Infra.Data.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
