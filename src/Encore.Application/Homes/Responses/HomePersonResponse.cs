using Encore.Domain.ValueObjects;

namespace Encore.Application.Homes.Responses
{
    public class HomePersonResponse
    {
        public string Name { get; private set; }
        public string SocialName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Nationality { get; private set; }
        public string Sex { get; private set; }
        public string DocumentType { get; private set; }
        public string Document { get; private set; }
        public bool IsHeadFamily { get; private set; }
    }
}
