namespace Encore.Application.Persons.Responses
{
    public class PersonHomeResponse
    {
        public string Name { get; set; }
        public string SocialName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Document { get; set; }
        public string DocumentType { get; set; }
        public string Email { get; set; }
        public string? ContactNumber { get; set; }
        public string SocialIdentification { get; set; }
        public bool IsHeadFamily { get; set; }
    }
}
