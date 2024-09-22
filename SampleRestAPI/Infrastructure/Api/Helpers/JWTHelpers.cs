using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SampleRestAPI.infrastructure.Api.DTO.Authentication;

namespace SampleRestAPI.infrastructure.Api.Helpers;

public static class JwtHelpers
{

    public static string GenerateToken(AuthenticationConfig configuration, Guid userId)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.JwtKey));
        
        var credentials = new SigningCredentials(key, configuration.Algorithm);
        
        var token = new JwtSecurityToken(
            issuer: configuration.JwtIssuer,
            audience: configuration.JwtIssuer,
            claims:
            [
                new Claim("userId", userId.ToString())
            ],
            expires: DateTime.Now.AddMinutes(configuration.JwtExpirationMinutes),
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    } 
    
    public static bool ValidateToken(AuthenticationConfig configuration, string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = configuration.TokenValidationParameters;
        
        try
        {
            tokenHandler.ValidateToken(token, validationParameters, out _);
            return true;
        }
        catch
        {
            return false;
        }
    }
    
}