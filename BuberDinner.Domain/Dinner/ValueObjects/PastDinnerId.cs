using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;
public sealed class PastDinnerId : ValueObject
{
    public Guid Value { get; set; }

    public PastDinnerId(Guid id)
    {
        Value = id;
    }

    public static PastDinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}