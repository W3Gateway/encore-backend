using Encore.Application.HealthConditions;
using Encore.Application.Persons.Responses;
using Encore.Application.SociodemographicSituations;
using Encore.Domain.Core.Messaging;
using Encore.Domain.Core.Responses;

namespace Encore.Application.Persons.Commands
{
    public class PersonCreateCommand : Command<Response<PersonResponse>>
    {
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
        public bool IsHeadFamily { get; set; }
        public Guid MicroregionId { get; set; }
        public Guid HomeId { get; set; }
        public SociodemographicSituationCommand SociodemographicSituation { get; set; }
        public HealthConditionCommand HealthCondition { get; set; }
    }
}