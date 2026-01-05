using Microsoft.AspNetCore.Identity;
using PagueiBaratoApi.Application;
using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Core;
using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Entities;
using PagueiBaratoApi.Infrastructure.Repository;
using PagueiBaratoApi.Infrastructure.Repository.Interface;

namespace PagueiBaratoApi.Api.Setup;

public static class DependencyInjection
{
    public static void AddApplications(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioApplication, UsuarioApplication>();
    }

    public static void AddCore(this IServiceCollection services)
    {
        services.AddScoped<ISenhaCore, SenhaCore>();
        services.AddScoped<IUsuarioCore, UsuarioCore>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }

    public static void AddPasswordHasher(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();
    }
}
