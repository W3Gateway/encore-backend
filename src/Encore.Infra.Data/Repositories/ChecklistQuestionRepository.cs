using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using Encore.Infra.Data.Context;

namespace Encore.Infra.Data.Repositories
{
    public class ChecklistQuestionRepository : Repository<OtherQuestion>, IChecklistQuestionRepository
    {
        public ChecklistQuestionRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
