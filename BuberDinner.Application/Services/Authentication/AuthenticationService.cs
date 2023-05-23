using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "Laura", "Brito", email, "token");
    }

    public AuthenticationResult Register(string firstName,
                                         string lastName,
                                         string email,
                                         string password)
    {
        //Check is user already exists

        // Create users (generate unique ID)

        // Create JWT Token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult(userId,
                                        firstName,
                                        lastName,
                                        email,
                                        token);
    }
}