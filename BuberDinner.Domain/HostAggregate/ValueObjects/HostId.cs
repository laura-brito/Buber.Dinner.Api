using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId(Guid id)
    {
        Value = id;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static HostId Create(string hostId)
    {
        return new(Guid.Parse(hostId));
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
