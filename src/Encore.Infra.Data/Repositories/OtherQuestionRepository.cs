using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using Encore.Infra.Data.Context;

namespace Encore.Infra.Data.Repositories
{
    public class OtherQuestionRepository : Repository<OtherQuestion>, IOtherQuestionRepository
    {
        public OtherQuestionRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
