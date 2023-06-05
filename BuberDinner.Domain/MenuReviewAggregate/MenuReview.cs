using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuReviewAggregate;

public sealed class MenuReview : AggregateRoot<MenuReviewId, Guid>
{
    public Rating Rating { get; private set; }
    public string Comment { get; private set; }
    public HostId HostId { get; private set; }
    public GuestId GuestId { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    protected MenuReview()
    {
    }

    private MenuReview(MenuReviewId id,
                      Rating rating,
                      string comment,
                      HostId hostId,
                      GuestId guestId,
                      DinnerId dinnerId,
                      DateTime createdDateTime,
                      DateTime updatedDateTime) : base(id)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static MenuReview Create(Rating rating,
                                    string comment,
                                    HostId hostId,
                                    GuestId guestId,
                                    DinnerId dinnerId,
                                    DateTime createdDateTime,
                                    DateTime updatedDateTime)
    {
        return new(MenuReviewId.CreateUnique(),
                   rating,
                   comment,
                   hostId,
                   guestId,
                   dinnerId,
                   createdDateTime,
                   updatedDateTime);
    }
}
