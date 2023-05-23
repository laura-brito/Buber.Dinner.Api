using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infra.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
