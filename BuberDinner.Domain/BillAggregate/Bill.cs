using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.BillAggregate;

public sealed class Bill : AggregateRoot<BillId, Guid>
{
    public DinnerId DinnerId { get; }
    public HostId HostId { get; }
    public GuestId GuestId { get; }
    public Price Price { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public Bill(BillId id,
                DinnerId dinnerId,
                HostId hostId,
                GuestId guestId,
                Price price,
                DateTime createdDateTime,
                DateTime updatedDateTime) : base(id)
    {
        DinnerId = dinnerId;
        HostId = hostId;
        GuestId = guestId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(DinnerId dinnerId,
                              HostId hostId,
                              GuestId guestId,
                              Price price,
                              DateTime createdDateTime,
                              DateTime updatedDateTime)
    {
        return new(BillId.CreateUnique(),
                   dinnerId,
                   hostId,
                   guestId,
                   price,
                   createdDateTime,
                   updatedDateTime);
    }
}
