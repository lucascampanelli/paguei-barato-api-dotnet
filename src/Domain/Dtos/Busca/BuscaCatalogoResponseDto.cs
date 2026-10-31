namespace PagueiBaratoApi.Domain.Dtos.Busca;

public record BuscaCatalogoResponseDto
{
    public IEnumerable<BuscaCatalogoItemResponseDto> Itens { get; init; } = Enumerable.Empty<BuscaCatalogoItemResponseDto>();
    public IEnumerable<BuscaFacetaDto> Facetas { get; init; } = Enumerable.Empty<BuscaFacetaDto>();
    public int Pagina { get; init; }
    public int TamanhoPagina { get; init; }
    public int TotalItens { get; init; }
}
