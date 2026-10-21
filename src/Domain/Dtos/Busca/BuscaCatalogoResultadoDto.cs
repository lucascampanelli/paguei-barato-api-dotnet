namespace PagueiBaratoApi.Domain.Dtos.Busca;

public record BuscaCatalogoDto
{
    public int ItemId { get; init; }
    public string Nome { get; init; } = string.Empty;
    public string? ImagemPath { get; init; }
}
