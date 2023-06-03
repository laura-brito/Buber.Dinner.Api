using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.User.ValueObjects;

public sealed class UserId : ValueObject
{
    public Guid Value { get; set; }

    private UserId(Guid id)
    {
        Value = id;
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}