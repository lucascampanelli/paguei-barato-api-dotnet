namespace PagueiBaratoApi.Domain.Dtos.Busca;

public record BuscaCatalogoResultadoResponseDto
{
    public IEnumerable<BuscaCatalogoResultadoDto> Itens { get; init; } = Enumerable.Empty<BuscaCatalogoResultadoDto>();
    public IEnumerable<BuscaFacetaDto> Facetas { get; init; } = Enumerable.Empty<BuscaFacetaDto>();
    public int Pagina { get; init; }
    public int TamanhoPagina { get; init; }
    public int TotalItens { get; init; }
}
