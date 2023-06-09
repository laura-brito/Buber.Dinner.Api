using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
public sealed class MenuReviewId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuReviewId()
    {
    }

    private MenuReviewId(Guid id)
    {
        Value = id;
    }
    public static MenuReviewId Create(Guid value)
    {
        return new MenuReviewId(value);
    }

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
