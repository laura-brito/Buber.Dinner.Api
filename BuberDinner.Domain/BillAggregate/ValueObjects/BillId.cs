using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.BillAggregate.ValueObjects;
public sealed class BillId : AggregateRootId<Guid>
{
    public override Guid Value { get; set; }

    private BillId(Guid id)
    {
        Value = Value;
    }

    public static BillId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
