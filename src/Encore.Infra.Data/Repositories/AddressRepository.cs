using Encore.Domain.Interfaces.Data;
using Encore.Domain.Models;
using Encore.Infra.Data.Context;

namespace Encore.Infra.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
