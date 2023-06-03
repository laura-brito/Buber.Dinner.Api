using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public UserId UserId { get; }

    public Guest(GuestId id) : base(id)
    {
    }
}
