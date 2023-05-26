using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("v1/auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(request.FirstName,
                                                     request.LastName,
                                                     request.Email,
                                                     request.Password);

        return authResult.Match(
                authResult => Ok(MapResultToResponse(authResult)),
                errors => Problem(errors));
    }

    private static AuthenticationResponse MapResultToResponse(AuthenticationResult authResult) => new(authResult.User.Id,
                                                                                                      authResult.User.FirstName,
                                                                                                      authResult.User.LastName,
                                                                                                      authResult.User.Email,
                                                                                                      authResult.Token);

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email,
                                                  request.Password);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized,
                           title: authResult.FirstError.Description);
        }

        return authResult.Match(
                authResult => Ok(MapResultToResponse(authResult)),
                errors => Problem(errors));
    }
}
