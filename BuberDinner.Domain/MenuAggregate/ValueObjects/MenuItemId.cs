using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;
public class MenuItemId : ValueObject
{
    public Guid Value { get; }
    private MenuItemId(Guid id)
    {
        Value = id;
    }

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid value)
    {
        return new MenuItemId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
