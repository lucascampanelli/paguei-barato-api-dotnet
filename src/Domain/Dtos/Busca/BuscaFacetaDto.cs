namespace PagueiBaratoApi.Domain.Dtos.Busca;

public record BuscaFacetaDto
{
    public string Faceta { get; init; } = string.Empty;
    public string Valor { get; init; } = string.Empty;
    public int Total { get; init; }
}
