using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using Encore.Infra.Data.Context;

namespace Encore.Infra.Data.Repositories
{
    public class SociodemographicSituationRepository : Repository<SociodemographicSituation>, ISociodemographicSituationRepository
    {
        public SociodemographicSituationRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
