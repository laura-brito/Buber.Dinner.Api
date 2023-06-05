namespace BuberDinner.Domain.Common.Models;

public abstract class AggregateRoot<TId, TIdType> : Entity<TId> where TId : AggregateRootId<TIdType>
{

    public new AggregateRootId<TIdType> Id { get; protected set; }
    protected AggregateRoot()
    {
    }

    protected AggregateRoot(TId id) : base(id)
    {
    }
}
