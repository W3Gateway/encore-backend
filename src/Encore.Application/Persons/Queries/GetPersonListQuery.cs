using Encore.Application.Persons.Responses;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Persons.Queries
{
    public class GetPersonListQuery : Query<IEnumerable<PersonResponse>?>
    {
        public Guid HomeId { get; }

        public GetPersonListQuery(Guid homeId) => HomeId = homeId;
    }
}
