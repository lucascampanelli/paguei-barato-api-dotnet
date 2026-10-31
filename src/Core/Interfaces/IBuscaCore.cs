using PagueiBaratoApi.Domain.Dtos.Busca;

namespace PagueiBaratoApi.Core.Interfaces;

public interface IBuscaCore
{
    Task<BuscaCatalogoResultadoResponseDto> BuscarAsync(BuscaCatalogoRequestDto requestDto);
}
