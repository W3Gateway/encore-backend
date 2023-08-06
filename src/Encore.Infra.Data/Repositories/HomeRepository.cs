using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using Encore.Infra.Data.Context;

namespace Encore.Infra.Data.Repositories
{
    public class HomeRepository : Repository<Home>, IHomeRepository
    {
        public HomeRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
