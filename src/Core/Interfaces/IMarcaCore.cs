using PagueiBaratoApi.Domain.Dtos.Marca;

namespace PagueiBaratoApi.Core.Interfaces;

public interface IMarcaCore
{
    Task<MarcaResponseDto> CriarAsync(MarcaCriarRequestDto requestDto, Guid criadoPorId);
    Task<MarcaResponseDto?> ObterPorIdAsync(int id);
    Task<IEnumerable<MarcaResponseDto>> ListarAsync(MarcaListarRequestDto? requestDto = null);
}
