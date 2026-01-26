using PagueiBaratoApi.Domain.Dtos.Marca;

namespace PagueiBaratoApi.Application.Interfaces;

public interface IMarcaApplication
{
    Task<MarcaResponseDto> CriarAsync(MarcaCriarRequestDto requestDto, Guid criadoPorId);
    Task<MarcaResponseDto> ObterPorIdAsync(int id);
    Task<IEnumerable<MarcaResponseDto>> ListarAsync(MarcaListarRequestDto? requestDto = null);
}
