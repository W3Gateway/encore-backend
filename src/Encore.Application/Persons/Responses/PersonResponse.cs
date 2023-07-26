namespace Encore.Application.Persons.Responses
{
    public class PersonResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SocialName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Sex { get; set; }
        public string SkinColor { get; set; }
        public string Document { get; set; }
        public string DocumentType { get; set; }
        public string Email { get; set; }
        public string? ContactNumber { get; set; }
        public string SocialIdentification { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public Guid MicroregionId { get; set; }
        public bool IsHeadFamily { get; set; }

        public PersonMicroregionResponse Microregion { get; set; }
        public PersonHomeResponse Home { get; set; }
    }
}
