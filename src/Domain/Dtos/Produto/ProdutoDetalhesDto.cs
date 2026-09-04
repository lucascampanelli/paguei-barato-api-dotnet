using PagueiBaratoApi.Domain.Dtos.Categoria;
using PagueiBaratoApi.Domain.Dtos.Marca;

namespace PagueiBaratoApi.Domain.Dtos.Produto;

public record ProdutoDetalhesDto
{
    public int Id { get; init; }
    public string Nome { get; init; }
    public MarcaResponseDto Marca { get; init; }
    public IEnumerable<CategoriaResponseDto> Categorias { get; init; }
    public Dictionary<string, string> Atributos { get; init; }
    public string ImagemPath { get; init; }
    public DateTime CriadoEm { get; init; }
}
