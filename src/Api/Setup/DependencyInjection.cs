using PagueiBaratoApi.Application;
using PagueiBaratoApi.Domain.Applications;
using PagueiBaratoApi.Domain.Repository;
using PagueiBaratoApi.Infrastructure.Repository;

namespace PagueiBaratoApi.Api.Setup;

public static class DependencyInjection
{
    public static void AddApplications(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioApplication, UsuarioApplication>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }
}
