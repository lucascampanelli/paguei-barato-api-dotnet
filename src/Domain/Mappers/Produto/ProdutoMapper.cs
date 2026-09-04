using PagueiBaratoApi.Domain.Dtos.Produto;
using PagueiBaratoApi.Domain.Mappers.Categoria;
using PagueiBaratoApi.Domain.Mappers.Marca;

namespace PagueiBaratoApi.Domain.Mappers.Produto;

public static class ProdutoMapper
{
    public static ProdutoDetalhesDto ToDetalhesDto(this Entities.Produto produto)
    {
        return new ProdutoDetalhesDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Marca = produto.Marca.ToResponseDto(),
            Categorias = produto.Categorias.Select(c => c.ToResponseDto()).ToList(),
            Atributos = produto.Atributos,
            ImagemPath = produto.ImagemPath,
            CriadoEm = produto.CriadoEm
        };
    }

    public static ProdutoResponseDto ToResponseDto(this ProdutoDetalhesDto produto, string imagemUrl)
    {
        return new ProdutoResponseDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Marca = produto.Marca,
            Categorias = produto.Categorias,
            Atributos = produto.Atributos,
            ImagemUrl = imagemUrl,
            CriadoEm = produto.CriadoEm
        };
    }
}