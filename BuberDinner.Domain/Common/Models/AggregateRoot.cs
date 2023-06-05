namespace BuberDinner.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull
{

    protected AggregateRoot()
    {
    }

    protected AggregateRoot(TId id) : base(id)
    {
    }
}
