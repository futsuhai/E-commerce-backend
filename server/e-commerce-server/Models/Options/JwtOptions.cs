using System.Text;
using Microsoft.IdentityModel.Tokens;

public static class JwtOptions
{
    public const string Secret = "qwerfdsa1234asdasdasdzzxcASASQWQWQW123123";

    public const string Issuer = "E-Commerce-Backend";

    public const string Audience = "E-Commerce";

    public static SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.UTF8.GetBytes(Secret));
}