using PagueiBaratoApi.Domain.Dtos.Categoria;

namespace PagueiBaratoApi.Domain.Mappers.Categoria;

public static class CategoriaMapper
{
    public static CategoriaResponseDto ToResponseDto(this Entities.Categoria categoria)
    {
        return new CategoriaResponseDto
        {
            Id = categoria.Id,
            Nome = categoria.Nome
        };
    }
}