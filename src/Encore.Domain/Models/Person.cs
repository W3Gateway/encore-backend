using Encore.Domain.Core.Models;

namespace Encore.Domain.Models
{
    public class Person : Entity<Person>
    {
        public string Name { get; set; }
        public string SocialName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Sex { get; set; }
        public string SkinColor { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string? ContactNumber { get; set; }
        public string SocialIdentification { get; set; }
        public string? NationalHealthRegister { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public Guid MicroregionId { get; set; }

        #region Mapping
        public Microregion Microregion { get; set; }
        public Home Home { get; set; }
        #endregion

    }

}
