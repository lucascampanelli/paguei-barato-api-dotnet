using PagueiBaratoApi.Domain.Dtos.Produto;
using PagueiBaratoApi.Domain.Mappers.Categoria;
using PagueiBaratoApi.Domain.Mappers.Marca;

namespace PagueiBaratoApi.Domain.Mappers.Produto;

public static class ProdutoMapper
{
    public static ProdutoResponseDto ToResponseDto(this Entities.Produto produto)
    {
        return new ProdutoResponseDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            MarcaId = produto.MarcaId,
            Marca = new(),
            Categorias = produto.Categorias.Select(c => c.ToResponseDto()).ToList(),
            Atributos = produto.Atributos,
            CriadoEm = produto.CriadoEm,
            CriadoPorId = produto.CriadoPorId
        };
    }
}