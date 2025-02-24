using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services.Token;
using Server.Services.User;

namespace Server.Controllers;

[Route("/user")]
[ApiController]

public class UserController(
    IUserService service, 
    IConfiguration config,
    ITokenService tokenService
) : ControllerBase {
    
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody]AccountData accountData) 
    {
        var res = await service.CreateUser(accountData);

        return Ok("User created successfully!");    
    }

    [Authorize]
    [HttpGet("/invitation")]
    public IActionResult GetInvitationURL() 
    {
        var userId = Guid.Empty;
        var localhost = config.GetClientUrl();
        return Ok($"{localhost}/invitation/{userId}");
    }

    [HttpPost("/invitation/{invite}")]
    public async Task<IActionResult> CreateUserWithInvite([FromBody]AccountData accountaData, [FromRoute]Guid invite) 
    {
        await service.CreateUser(accountaData, invite);

        return Ok("User created successfully!");
    }

    [HttpPost("/auth")]
    public async Task<IActionResult> Login([FromBody]LoginData LoginData) 
    {
        var user = await service.Authenticate(LoginData);
        if (user is null)
            return Unauthorized();

        var jwt = tokenService.Generate(user);
        return Ok(new { jwt });
    }
}