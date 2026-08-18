using Microsoft.EntityFrameworkCore;
using PagueiBaratoApi.Infrastructure.Setup;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Npgsql;

namespace PagueiBaratoApi.Api.Setup;

public static class DatabaseSetup
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var builder = new NpgsqlDataSourceBuilder(connectionString);
        builder.EnableDynamicJson();
        services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(builder.Build()));
    }
}
