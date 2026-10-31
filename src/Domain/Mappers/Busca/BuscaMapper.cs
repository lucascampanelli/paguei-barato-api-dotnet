using PagueiBaratoApi.Domain.Dtos.Busca;
using PagueiBaratoApi.Domain.Extensions;

namespace PagueiBaratoApi.Domain.Mappers.Busca;

public static class BuscaMapper
{
    public static BuscaCatalogoItemResponseDto ToResponseDto(
        this BuscaCatalogoResultadoDto item,
        string? imagemUrl)
    {
        return new BuscaCatalogoItemResponseDto
        {
            ItemId = item.ItemId,
            Tipo = item.Tipo.CapitalizarPrimeiraLetra(),
            Nome = item.Nome,
            ImagemUrl = imagemUrl
        };
    }
}
