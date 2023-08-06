using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using Encore.Infra.Data.Context;

namespace Encore.Infra.Data.Repositories
{
    public class FormRepository : Repository<Form>, IFormRepository
    {
        public FormRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
