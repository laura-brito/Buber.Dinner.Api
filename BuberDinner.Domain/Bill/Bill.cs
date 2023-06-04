using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Bill;

public sealed class Bill : AggregateRoot<BillId>
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
