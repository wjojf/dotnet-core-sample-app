using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SampleRestAPI.domain.workout;
using SampleRestAPI.infrastructure.EF;
using SampleRestAPI.infrastructure.Handlers;

namespace SampleRestAPI.infrastructure;

public static class ApplicationBundle
{

    public static void RegisterServices(WebApplicationBuilder builder)
    {

        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("postgres"));
        });
        
        _RegisterJWT(builder.Services, builder.Configuration);

        builder.Services.AddScoped<IWorkoutsRepository, WorkoutsRepository>();
        
    }
    
    private static void _RegisterJWT(IServiceCollection services, ConfigurationManager configurationManager)
    {
       services.AddAuthentication(options =>
       {
           options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
           options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
       })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters{
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configurationManager["Jwt:Issuer"],
                ValidAudience = configurationManager["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configurationManager["Jwt:Key"] ?? string.Empty)
                )
            };
        });
    }
    
    public static void Configure(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();
        app.UseAuthentication();
        
        RegisterHandlers(app);
    }
    
    private static void RegisterHandlers(IEndpointRouteBuilder app)
    {
        app.MapWorkoutsRoutes();
    } 
    
}