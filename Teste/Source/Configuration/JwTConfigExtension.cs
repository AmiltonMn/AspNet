namespace Server.Source.Configuration;

using Microsoft.AspNetCore.Authentication.JwtBearer;

public static class JwTConfigExtension
{

    /// <summary>
    /// Authenticate and authorizate JWT
    /// </summary>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddJwtAuthentication (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidIssuer = "para-lanche",
                    ValidateIssuerSigningKey = false,
                    ValidateLifetime = true,
                    IssuerSigningKey= configuration.GetJwtSecurityKey()
                };
            });

        services.AddAuthorization();

        return services;
    }
}