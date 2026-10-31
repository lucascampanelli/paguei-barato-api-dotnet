namespace PagueiBaratoApi.Domain.Dtos.Busca;

public record BuscaCatalogoResultadoDto
{
    public int ItemId { get; init; }
    public string Tipo { get; init; } = string.Empty;
    public string Nome { get; init; } = string.Empty;
    public string? ImagemPath { get; init; }
}
