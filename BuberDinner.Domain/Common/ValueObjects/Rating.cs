using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public Guid Id { get; set; }
    public HostId HostId { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    public double Value { get; private set; }

    public Rating(Guid id,
                  HostId hostId,
                  DinnerId dinnerId,
                  DateTime createdDateTime,
                  DateTime updatedDateTime,
                  double value)
    {
        Id = id;
        HostId = hostId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        Value = value;
    }

    public static Rating Create(HostId hostId,
                                DinnerId dinnerId,
                                DateTime createdDateTime,
                                DateTime updatedDateTime,
                                double value)
    {
        return new(Guid.NewGuid(),
                   hostId,
                   dinnerId,
                   createdDateTime,
                   updatedDateTime,
                   value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
