namespace PagueiBaratoApi.Domain.Dtos.Busca;

public record BuscaCatalogoItemResponseDto
{
    public int ItemId { get; init; }
    public string Tipo { get; init; } = string.Empty;
    public string Nome { get; init; } = string.Empty;
    public string? ImagemUrl { get; init; }
}
