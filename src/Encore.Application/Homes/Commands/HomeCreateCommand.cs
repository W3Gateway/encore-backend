namespace Encore.Application.Homes.Commands
{
    public class HomeCreateCommand : HomeCommand
    {
        public int AppId { get; set; }
        public Guid MicroregionId { get; set; }
    }

}
