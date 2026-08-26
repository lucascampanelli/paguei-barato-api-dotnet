namespace PagueiBaratoApi.Domain.Options;

public record AuthTokenOptions
{
    public static readonly string SectionName = "AuthToken";
    public string Issuer { get; init; } = string.Empty;
    public string Key { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public int MinutosParaExpirar { get; init; } = 15;
    public int DiasParaExpirarRefreshToken { get; init; } = 7;
}
