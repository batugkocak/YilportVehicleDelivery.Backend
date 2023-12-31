using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Extensions;

public static class ClaimExtensions
{
    public static void AddUsername(this ICollection<Claim> claims, string username)
    {
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub,username));
    }

    public static void AddName(this ICollection<Claim> claims, string name)
    {
        claims.Add(new Claim(JwtRegisteredClaimNames.Name, name));
    }

    public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
    {
        claims.Add(new Claim("nameIdentifier", nameIdentifier));
    }

    public static void AddRoles(this ICollection<Claim> claims, string[] roles)
    {
        roles.ToList().ForEach(role=>claims.Add(new Claim("roles", role)));
    }

    public static void AddVerificationType(this ICollection<Claim> claims, string verificationType)
    { 
        claims.Add(new Claim("verificationType", verificationType));
    }

}