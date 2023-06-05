using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;
public class GuestId : AggregateRootId<Guid>
{
    public override Guid Value { get; set; }

    private GuestId(Guid id)
    {
        Value = id;
    }

    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
