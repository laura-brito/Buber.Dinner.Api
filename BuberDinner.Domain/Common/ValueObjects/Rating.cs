using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public Rating(double value)
    {
        Value = value;
    }

    public double Value { get; private set; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
