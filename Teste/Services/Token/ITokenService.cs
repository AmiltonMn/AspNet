namespace Server.Services.Token;

using Server.Entities;

public interface ITokenService 
{
    string Generate(ApplicationUser user);
}