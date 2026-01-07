namespace PagueiBaratoApi.Domain.Options;

public record class Secrets
{
    public TokenSecrets Token { get; init; } = new();
}
