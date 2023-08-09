using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using Encore.Infra.Data.Context;

namespace Encore.Infra.Data.Repositories
{
    public class HealthConditionRepository : Repository<HealthCondition>, IHealthConditionRepository
    {
        public HealthConditionRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
