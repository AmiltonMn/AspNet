namespace Server.Source.Configuration;

using Microsoft.IdentityModel.Tokens;

public static class ConfigurationExtension
{
    public static string GetClientUrl(this IConfiguration configuration) 
    {
        const string key = "FrontendURL";

        var clientUrl = configuration[key]
            ?? throw new Exception($"Missing client URL on appsettings with key '{key}'");

        return clientUrl;
    }

    public static string GetJwtSecret(this IConfiguration configuration)
    {
        const string key = "JWTSecret";

        var jwtSecret = configuration[key]
            ?? throw new Exception($"Missing client URL on appsettings with key '{key}'");

        return jwtSecret;
    }

    public static SymmetricSecurityKey GetJwtSecurityKey(this IConfiguration configuration)
    {
        var secretKey = configuration.GetJwtSecret();
        var secretBytes = Convert.FromBase64String(secretKey);
        
        return new SymmetricSecurityKey(secretBytes);
    }
}