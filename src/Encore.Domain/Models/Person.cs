using Encore.Domain.Core.Models;
using Encore.Domain.Homes;

namespace Encore.Domain.Models
{
    public class Person : Entity<Person>
    {
        public string Name { get; private set; }
        public string SocialName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Nationality { get; private set; }
        public string Sex { get; private set; }
        public string SkinColor { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string? ContactNumber { get; private set; }
        public string SocialIdentification { get; private set; }
        public string DocumentType { get; private set; }
        public string FatherName { get; private set; }
        public string MotherName { get; private set; }
        public bool IsHeadFamily { get; private set; }
        public Guid MicroregionId { get; private set; }
        public Guid HomeId { get; private set; }

        #region Mapping
        public Microregion Microregion { get; private set; }
        public Home Home { get; private set; }
        #endregion

        public Person(string name, string socialName, DateTime birthDate, string nationality, string sex, string skinColor, string document, string email, string? contactNumber, string socialIdentification, string? nationalHealthRegister, string fatherName, string motherName, bool isHeadFamily, Guid microregionId, Guid homeId)
        {
            Name = name;
            SocialName = socialName;
            BirthDate = birthDate;
            Nationality = nationality;
            Sex = sex;
            SkinColor = skinColor;
            Document = document;
            Email = email;
            ContactNumber = contactNumber;
            SocialIdentification = socialIdentification;
            DocumentType = nationalHealthRegister;
            FatherName = fatherName;
            MotherName = motherName;
            IsHeadFamily = isHeadFamily;
            MicroregionId = microregionId;
            HomeId = homeId;
        }

    }

}
