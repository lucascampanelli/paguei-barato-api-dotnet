using Microsoft.AspNetCore.Identity;
using PagueiBaratoApi.Application;
using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Core;
using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Entities;
using PagueiBaratoApi.Domain.Options;
using PagueiBaratoApi.Infrastructure.Adapters;
using PagueiBaratoApi.Infrastructure.Adapters.Interfaces;
using PagueiBaratoApi.Infrastructure.Repository;
using PagueiBaratoApi.Infrastructure.Repository.Interfaces;

namespace PagueiBaratoApi.Api.Setup;

public static class DependencyInjection
{
    public static void AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthTokenOptions>(configuration.GetSection(AuthTokenOptions.SectionName));
        services.Configure<AzureStorageOptions>(configuration.GetSection(AzureStorageOptions.SectionName));
    }

    public static void AddApplications(this IServiceCollection services)
    {
        services.AddScoped<IMarcaApplication, MarcaApplication>();
        services.AddScoped<IProdutoApplication, ProdutoApplication>();
        services.AddScoped<IUsuarioApplication, UsuarioApplication>();
    }

    public static void AddCore(this IServiceCollection services)
    {
        services.AddScoped<IMarcaCore, MarcaCore>();
        services.AddScoped<IProdutoCore, ProdutoCore>();
        services.AddScoped<ISenhaCore, SenhaCore>();
        services.AddScoped<ITokenCore, TokenCore>();
        services.AddScoped<IUsuarioCore, UsuarioCore>();
    }

    public static void AddAdapters(this IServiceCollection services)
    {
        services.AddScoped<IImagensAdapter, ImagensAdapter>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMarcaRepository, MarcaRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }

    public static void AddPasswordHasher(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();
    }
}
