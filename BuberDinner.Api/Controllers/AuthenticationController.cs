using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("v1/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _authenticationService.Register(request.FirstName,
                                                     request.LastName,
                                                     request.Email,
                                                     request.Password);

        var response = new AuthenticationResponse(result.Id,
                                                  result.FirstName,
                                                  result.LastName,
                                                  result.Email,
                                                  result.Token);
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _authenticationService.Login(request.Email,
                                                  request.Password);

        var response = new AuthenticationResponse(result.Id,
                                                  result.FirstName,
                                                  result.LastName,
                                                  result.Email,
                                                  result.Token);
        return Ok(response);
    }
}
