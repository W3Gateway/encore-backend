using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Core.Validations
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MaxItemsAttribute : ValidationAttribute
    {
        private readonly int _maxItems;
        private readonly int _minItems;

        public MaxItemsAttribute(int maxItems, int minItems = 0)
        {
            _maxItems = maxItems;
            _minItems = minItems;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IEnumerable<object> maxList && maxList.Count() > _maxItems)
            {
                return new ValidationResult($"A lista não pode conter mais de {_maxItems} itens.");
            }

            if (value is IEnumerable<object> minList && minList.Count() < _minItems)
            {
                return new ValidationResult($"A lista não pode conter menos de {_minItems} itens.");
            }

            return ValidationResult.Success;
        }
    }
}
