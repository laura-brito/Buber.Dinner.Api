using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuReviewAggregate;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public Rating Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }


    public MenuReview(MenuReviewId id,
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
