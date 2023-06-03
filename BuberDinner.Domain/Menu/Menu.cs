using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{

    private readonly List<MenuSection> _sections = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<DinnerId> _dinnerIds = new();

    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }
    public HostId HostId { get; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }


    public Menu(MenuId id,
                string name,
                string description,
                float averageRating,
                HostId hostId,
                DateTime createdDateTime,
                DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(string name,
                              string description,
                              float averageRating,
                              HostId hostId,
                              DateTime createdDateTime,
                              DateTime updatedDateTime)
    {
        return new(MenuId.CreateUnique(),
                   name,
                   description,
                   averageRating,
                   hostId,
                   createdDateTime,
                   updatedDateTime);
    }
}
