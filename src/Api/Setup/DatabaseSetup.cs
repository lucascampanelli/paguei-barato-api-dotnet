using Microsoft.EntityFrameworkCore;
using PagueiBaratoApi.Infrastructure.Setup;

namespace PagueiBaratoApi.Api.Setup;

public static class DatabaseSetup
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));
    }
}
