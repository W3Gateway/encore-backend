using Encore.Domain.Core.Intefaces;
using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Encore.Domain.Core.Models
{
    public abstract class Entity<T> : AbstractValidator<T>, IAggregateRoot
        where T : Entity<T>
    {
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;

        [NotMapped]
        [JsonIgnore]
        public ValidationResult ValidationResult { get; protected set; } = new ValidationResult();

        public virtual Task<bool> IsValidAsync() => Task.FromResult(true);

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b) => !(a == b);

        public override bool Equals(object? obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo is null)
                return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

        public override string ToString() => $"{GetType().Name} [Id={Id}]";
    }
}