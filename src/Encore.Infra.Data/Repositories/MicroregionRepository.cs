using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using Encore.Infra.Data.Context;

namespace Encore.Infra.Data.Repositories
{
    public class MicroregionRepository : Repository<Microregion>, IMicroregionRepository
    {
        public MicroregionRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
