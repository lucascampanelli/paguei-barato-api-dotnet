using PagueiBaratoApi.Domain.Dtos.Marca;

namespace PagueiBaratoApi.Infrastructure.Repository.Interfaces;

public interface IMarcaRepository
{
    Task<MarcaResponseDto> CriarAsync(MarcaCriarRequestDto marcaDto, Guid criadoPorId);
    Task<MarcaResponseDto?> ObterPorIdAsync(int id);
    Task<IEnumerable<MarcaResponseDto>> ListarAsync(MarcaListarRequestDto? requestDto = null);
}
