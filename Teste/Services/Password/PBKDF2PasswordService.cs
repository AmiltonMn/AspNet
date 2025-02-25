namespace Server.Services.Password;

using Microsoft.AspNetCore.Identity;

public class PBKDF2PasswordService : IPasswordService
{

    readonly PasswordHasher<string> hasher= new();

    public string Hash(string password)
        => hasher.HashPassword(password, password);

    public bool Verify(string password, string hashedPass)
    {
        var hash = hasher.VerifyHashedPassword(password, hashedPass, password);
        return hash == PasswordVerificationResult.Success;
    }
} 