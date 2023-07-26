using Encore.Application.Persons.Responses;
using Encore.Application.Persons.Search;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Persons.Queries
{
    public class GetPersonListQuery : QueryList<IEnumerable<PersonResponse>?, PersonSearch>
    {
        public Guid HomeId { get; }
    }
}
