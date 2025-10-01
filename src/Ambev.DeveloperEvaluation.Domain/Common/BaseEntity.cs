using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Common;

public abstract class BaseEntity<TKey> : IComparable<BaseEntity<TKey>> where TKey : IComparable<TKey>
{
    public TKey Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; }    
    public DateTime? UpdatedAt { get; set; }
    public Task<IEnumerable<ValidationErrorDetail>> ValidateAsync()
    {
        return Validator.ValidateAsync(this);
    }

    public int CompareTo(BaseEntity<TKey>? other)
    {
        if (other == null)
        {
            return 1;
        }

        return Id.CompareTo(other.Id);
    }
}
