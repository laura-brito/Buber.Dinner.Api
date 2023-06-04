using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;
public sealed class PendingDinnerId : ValueObject
{
    public Guid Value { get; set; }

    public PendingDinnerId(Guid id)
    {
        Value = id;
    }

    public static PendingDinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}