using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Infra.Persistence.Repository;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public void Add(User user) => _users.Add(user);

    public User? GetUserByEmail(string email) => _users.SingleOrDefault(u => u.Email == email);
}