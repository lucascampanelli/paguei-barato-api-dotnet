
using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Marca;
using PagueiBaratoApi.Infrastructure.Repository.Interfaces;

namespace PagueiBaratoApi.Core;

public class MarcaCore : IMarcaCore
{
    public readonly IMarcaRepository _marcaRepository;

    public MarcaCore(IMarcaRepository marcaRepository)
    {
        _marcaRepository = marcaRepository;
    }

    public async Task<MarcaResponseDto> CriarAsync(MarcaCriarRequestDto requestDto, Guid criadoPorId)
        => await _marcaRepository.CriarAsync(requestDto, criadoPorId);

    public async Task<MarcaResponseDto?> ObterPorIdAsync(int id)
        => await _marcaRepository.ObterPorIdAsync(id);

    public async Task<IEnumerable<MarcaResponseDto>> ListarAsync(MarcaListarRequestDto? requestDto = null)
        => await _marcaRepository.ListarAsync(requestDto);
}
