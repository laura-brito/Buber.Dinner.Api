using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("v1/dinners")]
public class DinnersController : ApiController
{

    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok();
    }
}