using Microsoft.AspNetCore.Mvc;
using SampleRestAPI.Domain.User;
using SampleRestAPI.infrastructure.Api.DTO.Authentication;
using SampleRestAPI.infrastructure.Api.Helpers;

namespace SampleRestAPI.Infrastructure.Api.Handlers;

public static class AuthorizationHandlers
{
    public static void MapAuthorizationHandlers(this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/login",
            async Task<IResult>(
                [FromBody] LoginRequestDto dto, 
                [FromServices] AuthenticationConfig config, 
                [FromServices] IUsersRepository usersRepository) =>
            {
                
                var user = await usersRepository.GetUserByUsername(dto.Username);
                if (user == null)
                {
                    return TypedResults.NotFound();
                }

                var passwordMatch = usersRepository.PasswordMatches(user.Id, dto.Password);
                if (!passwordMatch)
                {
                    return TypedResults.Forbid();
                }

                var token = JwtHelpers.GenerateToken(config, user.Id);
                return TypedResults.Ok(new LoginResponseDto(token));
            });
    }
}