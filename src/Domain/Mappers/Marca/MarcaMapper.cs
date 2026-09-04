using PagueiBaratoApi.Domain.Dtos.Marca;

namespace PagueiBaratoApi.Domain.Mappers.Marca;

public static class MarcaMapper
{
    public static Entities.Marca ToEntity(this MarcaCriarRequestDto requestDto, Guid criadoPorId)
    {
        return new Entities.Marca
        {
            Nome = requestDto.Nome,
            CriadoPorId = criadoPorId,
            CriadoEm = DateTime.UtcNow
        };
    }

    public static MarcaResponseDto ToResponseDto(this Entities.Marca marca)
    {
        return new MarcaResponseDto
        {
            Id = marca.Id,
            Nome = marca.Nome
        };
    }
}