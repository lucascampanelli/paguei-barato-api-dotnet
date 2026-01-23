using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PagueiBaratoApi.Api.Setup;

public static class AuthenticationSetup
{
    public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var issuer = configuration["Token:Issuer"] ?? throw new ArgumentNullException("Issuer is not configured");
        var audience = configuration["Token:Audience"] ?? throw new ArgumentNullException("Audience is not configured");
        var key = configuration["Token:Key"] ?? throw new ArgumentNullException("Key is not configured");

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });
    }
}
