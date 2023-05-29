using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ErrorOr;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Authentication.Commands.Register;

namespace BuberDinner.Api.Controllers;

[Route("v1/auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName,
                                                     request.LastName,
                                                     request.Email,
                                                     request.Password);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

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
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await _mediator.Send(query);

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
