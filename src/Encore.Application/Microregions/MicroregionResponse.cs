namespace Encore.Application.Microregions
{
    public class MicroregionResponse
    {
        public string Name { get; set; }

        public MicroregionResponse(string name)
        {
            Name = name;
        }
    }
}
