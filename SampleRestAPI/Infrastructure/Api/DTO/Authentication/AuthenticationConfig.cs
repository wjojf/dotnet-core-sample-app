using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SampleRestAPI.infrastructure.Api.DTO.Authentication;

public record AuthenticationConfig
{
    public required string JwtKey { get; init; }
    public required string JwtIssuer { get; init; }

    public required int JwtExpirationMinutes { get; init; } = 60;
    
    public string Algorithm { get; init; } = SecurityAlgorithms.HmacSha256;
    
    public TokenValidationParameters TokenValidationParameters => new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = JwtIssuer,
        ValidAudience = JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey))
    };

    public AuthenticationConfig(IConfiguration configuration)
    {
        JwtKey = configuration["Jwt:Key"] ?? string.Empty;
        JwtIssuer = configuration["Jwt:Issuer"] ?? string.Empty;
        JwtExpirationMinutes = int.Parse(configuration["Jwt:ExpirationMinutes"] ?? "60");
        Algorithm = configuration["Jwt:Algorithm"] ?? SecurityAlgorithms.HmacSha256;
    }
}