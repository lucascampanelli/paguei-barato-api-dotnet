namespace PagueiBaratoApi.Infrastructure.Adapters.Interfaces;

public interface IImagensAdapter
{
    Task<string?> ResolverUrlAsync(string? path);
}