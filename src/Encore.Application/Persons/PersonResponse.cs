namespace Encore.Application.Persons
{
    public class PersonResponse
    {
        public string Name { get; set; }
        public string SocialName { get; set; }
        public string Document { get; set; }
        public string? NationalHealthRegister { get; set; }
        public string Email { get; set; }
        public string? ContactNumber { get; set; }

        public PersonResponse(string name, string socialName, string document, string? nationalHealthRegister, string email, string? contactNumber)
        {
            Name = name;
            SocialName = socialName;
            Document = document;
            NationalHealthRegister = nationalHealthRegister;
            Email = email;
            ContactNumber = contactNumber;
        }
    }
}
