namespace Server.Source.Services.Token;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.IdentityModel.Tokens;

using Configuration;
using Source.Entities;

public class JWTService(IConfiguration config) : ITokenService
{
    public string Generate(ApplicationUser user)
    {
        var jwt = new JwtSecurityToken(
            claims: [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
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