using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PagueiBaratoApi.Api.Setup;

public static class AuthenticationSetup
{
    public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var issuer = configuration["AuthToken:Issuer"] ?? throw new ArgumentNullException("Issuer is not configured");
        var audience = configuration["AuthToken:Audience"] ?? throw new ArgumentNullException("Audience is not configured");
        var key = configuration["AuthToken:Key"] ?? throw new ArgumentNullException("Key is not configured");
        var keyBytes = Encoding.UTF8.GetBytes(key);

        if (keyBytes.Length < 16)
            throw new ArgumentException(key = "AuthToken:Key must contain at least 16 bytes for HS256.");

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
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
                };
            });
    }
}
