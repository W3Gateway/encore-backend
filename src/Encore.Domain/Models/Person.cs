using Encore.Domain.Core.Models;

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
        public string DocumentType { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string? ContactNumber { get; private set; }
        public string SocialIdentification { get; private set; }
        public string FatherName { get; private set; }
        public string MotherName { get; private set; }
        public bool IsHeadFamily { get; private set; }
        public Guid MicroregionId { get; private set; }
        public Guid HomeId { get; private set; }
        public Guid SociodemographicSituationId { get; set; }
        public Guid HealthConditionId { get; set; }

        #region Mapping
        public Microregion Microregion { get; private set; }
        public Home Home { get; private set; }
        public SociodemographicSituation SociodemographicSituation { get; set; }
        public HealthCondition HealthCondition { get; set; }
        public IEnumerable<Visit> Visits { get; set; }
        #endregion

        public Person() { }

        public Person(string name, string socialName, DateTime birthDate, string nationality, string sex, string skinColor, string document, string documentType, string email, string? contactNumber, string socialIdentification, string fatherName, string motherName, bool isHeadFamily, Guid microregionId, Guid sociodemographicSituationId, Guid healthConditionId, Guid homeId)
        {
            Name = name;
            SocialName = socialName;
            BirthDate = birthDate;
            Nationality = nationality;
            Sex = sex;
            SkinColor = skinColor;
            Document = document;
            DocumentType = documentType;
            Email = email;
            ContactNumber = contactNumber;
            SocialIdentification = socialIdentification;
            FatherName = fatherName;
            MotherName = motherName;
            IsHeadFamily = isHeadFamily;
            MicroregionId = microregionId;
            SociodemographicSituationId = sociodemographicSituationId;
            HealthConditionId = healthConditionId;
            HomeId = homeId;
        }

        public void CopyProperties(string name, string socialName, DateTime birthDate, string nationality, string sex, string skinColor, string document, string documentType, string email, string? contactNumber, string socialIdentification, string fatherName, string motherName, bool isHeadFamily, Guid microregionId, Guid homeId)
        {
            Name = name;
            SocialName = socialName;
            BirthDate = birthDate;
            Nationality = nationality;
            Sex = sex;
            SkinColor = skinColor;
            Document = document;
            DocumentType = documentType;
            Email = email;
            ContactNumber = contactNumber;
            SocialIdentification = socialIdentification;
            FatherName = fatherName;
            MotherName = motherName;
            IsHeadFamily = isHeadFamily;
            MicroregionId = microregionId;
            HomeId = homeId;
        }

    }

}
