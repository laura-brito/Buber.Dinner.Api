namespace BuberDinner.Domain.Common.Models;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType()) return false;

        var ValueObject = (ValueObject)obj;

        return GetEqualityComponents()
                .SequenceEqual(ValueObject.GetEqualityComponents());
    }

    public override int GetHashCode() => GetEqualityComponents()
                                            .Select(x => x?.GetHashCode() ?? 0)
                                            .Aggregate((x, y) => x ^ y);

    public bool Equals(ValueObject? other) => Equals((object?)other);

    public static bool operator ==(ValueObject left, ValueObject right) => Equals(left, right);

    public static bool operator !=(ValueObject left, ValueObject right) => !Equals(left, right);

}

public class Price : ValueObject
{
    public decimal Amount { get; private set; }
    public decimal Currency { get; private set; }

    public Price(decimal amount, decimal currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}