using Encore.Domain.Core.Messaging;
using FluentValidation.Results;

namespace Encore.Application.Homes.Commands
{
    public class HomeUpdateListCommand : Command<ValidationResult>
    {
        public List<HomeUpdateCommand> Homes { get; set; }
        public bool ExecuteTransaction { get; set; } = true;
    }
}
