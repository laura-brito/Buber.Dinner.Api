using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<Rating> _ratings = new();
    private readonly List<UpcomingDinnerId> _upcomingDinnerIds = new();
    private readonly List<PastDinnerId> _pastDinnerIds = new();
    private readonly List<PendingDinnerId> _pendingDinnerIds = new();


    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();
    public IReadOnlyList<UpcomingDinnerId> UpcomingDinnerId => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<PastDinnerId> PastDinnerId => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<PendingDinnerId> PendingDinnerId => _pendingDinnerIds.AsReadOnly();


    public Guest(GuestId id,
                 string firstName,
                 string lastName,
                 string profileImage,
                 AverageRating averageRating,
                 UserId userId,
                 DateTime createdDateTime,
                 DateTime updatedDateTime) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest Create(string firstName,
                 string lastName,
                 string profileImage,
                 AverageRating averageRating,
                 UserId userId,
                 DateTime createdDateTime,
                 DateTime updatedDateTime)
    {
        return new(GuestId.CreateUnique(),
                   firstName,
                   lastName,
                   profileImage,
                   averageRating,
                   userId,
                   createdDateTime,
                   updatedDateTime);
    }
}
