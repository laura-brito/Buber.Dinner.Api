using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;
public sealed class UpcomingDinnerId : ValueObject
{
    public Guid Value { get; set; }

    public UpcomingDinnerId(Guid id)
    {
        Value = id;
    }

    public static UpcomingDinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}