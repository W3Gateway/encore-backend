using Encore.Application.Homes.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;

namespace Encore.Application.Homes.Commands
{
    public class HomeCreateListCommand : Command<Response<List<HomeListResponse>>>
    {
        public IEnumerable<HomeCreateCommand> Homes { get; set; }
        public bool ExecuteTransaction { get; set; } = true;
    }

}
