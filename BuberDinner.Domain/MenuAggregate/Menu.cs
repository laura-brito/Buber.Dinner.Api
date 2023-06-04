using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{

    private readonly List<MenuSection> _sections = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<DinnerId> _dinnerIds = new();

    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get; }
    public HostId HostId { get; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }


    public Menu(MenuId id,
                HostId hostId,
                string name,
                string description,
                AverageRating averageRating,
                List<MenuSection>? sections) : base(id)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        HostId = hostId;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
        _sections = sections;
    }

    public static Menu Create(HostId hostId,
                              string name,
                              string description,
                              List<MenuSection>? sections
                              )
    {
        return new(MenuId.CreateUnique(),
                   hostId,
                   name,
                   description,
                   AverageRating.Create(),
                   sections ?? new());
    }
}
