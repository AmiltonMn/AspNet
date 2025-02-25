namespace Server.Configuration;

using System.Security.Claims;

public static class ControllerExtension
{
    public static Guid? GetClaimId(this ClaimsPrincipal claims)
    {
        var claim = claims.FindFirst(ClaimTypes.NameIdentifier);
        if (claim is null)
            return null;

        if (!Guid.TryParse(claim.Value, out var id))
            return null;

        return id;
    }
}