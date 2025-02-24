using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[ApiController]
[Route("/")]

public class StatusController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
        => Ok("Server Running...");
}