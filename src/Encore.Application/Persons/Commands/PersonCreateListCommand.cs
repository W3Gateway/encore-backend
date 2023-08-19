using Encore.Application.Persons.Responses;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;

namespace Encore.Application.Persons.Commands
{
    public class PersonCreateListCommand : Command<Response<List<PersonListResponse>>>
    {
        public IEnumerable<PersonCreateCommand> Persons { get; set; }
        public bool ExecuteTransaction { get; set; } = true;
    }
}