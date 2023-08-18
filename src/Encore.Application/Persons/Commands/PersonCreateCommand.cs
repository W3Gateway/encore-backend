using Encore.Application.Homes.Commands;

namespace Encore.Application.Persons.Commands
{
    public class PersonCreateCommand : PersonCommand
    {
        public int AppId { get; set; }
    }
}