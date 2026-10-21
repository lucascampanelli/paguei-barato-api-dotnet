using PagueiBaratoApi.Domain.Dtos.Busca;

namespace PagueiBaratoApi.Core.Interfaces;

public interface IBuscaCore
{
    Task<BuscaCatalogoResponseDto> BuscarAsync(BuscaCatalogoRequestDto requestDto);
}
