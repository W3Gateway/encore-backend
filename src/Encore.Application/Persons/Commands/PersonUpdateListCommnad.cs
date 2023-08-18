using Encore.Domain.Core.Messaging;
using FluentValidation.Results;

namespace Encore.Application.Persons.Commands
{
    public class PersonUpdateListCommnad : Command<ValidationResult>
    {
        public List<PersonUpdateCommand> Persons { get; set; }
        public bool ExecuteTransaction { get; set; } = true;
    }
}
