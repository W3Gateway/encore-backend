using Encore.Application.Persons.Responses;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Persons.Queries
{
    public class GetPersonListQuery : QueryList<IEnumerable<PersonResponse>?, PersonResponse>
    {
        public Guid HomeId { get; }
    }
}
