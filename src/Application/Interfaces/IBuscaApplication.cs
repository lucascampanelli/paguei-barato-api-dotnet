using PagueiBaratoApi.Domain.Dtos.Busca;

namespace PagueiBaratoApi.Application.Interfaces;

public interface IBuscaApplication
{
    Task<BuscaCatalogoResponseDto> BuscarAsync(BuscaCatalogoRequestDto requestDto);
}
