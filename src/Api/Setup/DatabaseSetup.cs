using Microsoft.EntityFrameworkCore;
using Npgsql;
using PagueiBaratoApi.Infrastructure.Setup;

namespace PagueiBaratoApi.Api.Setup;

public static class DatabaseSetup
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var builder = new NpgsqlDataSourceBuilder(connectionString);
        builder.EnableDynamicJson();
        var dataSource = builder.Build();

        services.AddSingleton(dataSource);
        services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(dataSource));
    }
}
