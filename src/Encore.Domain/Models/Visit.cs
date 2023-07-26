using Encore.Domain.Core.Models;
using Encore.Domain.Homes;
using FluentValidation;
using FluentValidation.Results;

namespace Encore.Domain.Models
{
    public class Visit : Entity<Visit>
    {
        public Guid AgentId { get; set; }
        public Guid PersonId { get; set; }
        public Guid HomeId { get; set; }
        public Guid MicroregionId { get; set; }

        #region Mapping
        public Person Person { get; set; }
        public Agent Agent { get; set; }
        public Home Home { get; set; }
        public Microregion Microregion { get; set; }
        public IEnumerable<QuestionAnswer> Answers { get; set; }
        #endregion

        public Visit(){}
        public Visit(Guid agentId, Guid personId, Guid homeId, Guid microregionId, IEnumerable<QuestionAnswer> answers)
        {
            AgentId = agentId;
            PersonId = personId;
            HomeId = homeId;
            MicroregionId = microregionId;
            Answers = answers;
        }

        public void CopyProperties(Guid agentId, Guid personId, Guid homeId, Guid microregionId, IEnumerable<QuestionAnswer> answers)
        {
            AgentId = agentId;
            PersonId = personId;
            HomeId = homeId;
            MicroregionId = microregionId;
            Answers = answers;
        }

        public override async Task<bool> IsValidAsync()
        {
            RuleFor(v => v.AgentId).NotEmpty().WithMessage("O agente é de preenchimento obrigatório"); ;
            RuleFor(v => v.MicroregionId).NotEmpty().WithMessage("A microarea é de preenchimento obrigatório");
            RuleFor(v => v.PersonId).NotEmpty().WithMessage("O indivíduo é de preenchimento obrigatório");
            RuleFor(v => v.HomeId).NotEmpty().WithMessage("O domicílio é de preenchimento obrigatório");
            RuleFor(v => v.Answers).NotEmpty().WithMessage("O formulário não foi respondido corretamente");

            ValidationResult = await ValidateAsync(this);
            return ValidationResult.IsValid;
        }

    }

}
