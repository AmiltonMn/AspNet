namespace Server.Source.Services.Token;

using Server.Source.Entities;

public interface ITokenService 
{
    string Generate(ApplicationUser user);
}