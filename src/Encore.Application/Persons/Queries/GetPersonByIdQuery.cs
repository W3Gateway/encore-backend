using Encore.Application.Persons.Responses;
using Encore.Domain.Core.Messaging;

namespace Encore.Application.Persons.Queries
{
    public class GetPersonByIdQuery : Query<PersonResponse?>
    {
        public Guid Id { get; }

        public GetPersonByIdQuery(Guid id) => Id = id;
    }
}
