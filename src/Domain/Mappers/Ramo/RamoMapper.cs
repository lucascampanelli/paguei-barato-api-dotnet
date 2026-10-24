using PagueiBaratoApi.Domain.Dtos.Ramo;

namespace PagueiBaratoApi.Domain.Mappers.Ramo;

public static class RamoMapper
{
    public static RamoResponseDto ToResponseDto(this Entities.Ramo ramo)
    {
        return new RamoResponseDto
        {
            Id = ramo.Id,
            Nome = ramo.Nome,
            Descricao = ramo.Descricao
        };
    }
}
