using SampleRestAPI.infrastructure.Api.Helpers;

namespace SampleRestAPI.infrastructure.Api.DTO.Authentication;

public record LoginRequestDto
{
    
    public string Username { get; init; }
    public string Password { get; init; }

    public LoginRequestDto(string Username, string Password)
    {
        this.Username = Username;
        this.Password = PasswordHelpers.HashPassword(Password);
    }
};


public record LoginResponseDto(string Token);

public record RegisterRequestDto(string Username, string Password);
