namespace Encore.Application.Homes.Commands
{
    public class HomeUpdateCommand : HomeCommand
    {
        public Guid Id { get; set; }
        public bool ExecuteTransaction { get; set; } = true;
    }
}
