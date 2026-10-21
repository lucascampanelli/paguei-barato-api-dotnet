namespace PagueiBaratoApi.Domain.Dtos.Busca;

public record BuscaCatalogoRequestDto
{
    public string? Termo { get; init; }
    public string? Tipo { get; init; }
    public string? Categoria { get; init; }
    public string? Ramo { get; init; }
    public string? Cidade { get; init; }
    public string? Estado { get; init; }
    public string? Bairro { get; init; }
    public string? Marca { get; init; }
    public int Pagina { get; init; } = 1;
    public int TamanhoPagina { get; init; } = 20;
}
