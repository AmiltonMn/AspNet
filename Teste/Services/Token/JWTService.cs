using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Server.Entities;

namespace Server.Services.Token;

public class JWTService(IConfiguration config) : ITokenService
{
    public string Generate(ApplicationUser user)
    {
        var jwt = new JwtSecurityToken(
            claims: [
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            ],
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: new SigningCredentials(
                config.GetJwtSecurityKey(),
                SecurityAlgorithms.HmacSha256Signature
            )
        );

        var handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(jwt);
    }
}