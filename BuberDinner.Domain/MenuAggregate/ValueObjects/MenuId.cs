using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObject
{
    public Guid Value { get; }
    private MenuId(Guid id)
    {
        Value = id;
    }

    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
