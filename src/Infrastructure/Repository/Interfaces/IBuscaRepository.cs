using PagueiBaratoApi.Domain.Dtos.Busca;

namespace PagueiBaratoApi.Infrastructure.Repository.Interfaces;

public interface IBuscaRepository
{
    Task<BuscaCatalogoResponseDto> BuscarAsync(BuscaCatalogoRequestDto requestDto);
}
