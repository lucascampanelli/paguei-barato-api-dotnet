using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Marca;

namespace PagueiBaratoApi.Application;

public class MarcaApplication : IMarcaApplication
{
    public readonly IMarcaCore _marcaCore;

    public MarcaApplication(IMarcaCore marcaCore)
    {
        _marcaCore = marcaCore;
    }

    public async Task<MarcaResponseDto> CriarAsync(MarcaCriarRequestDto requestDto, Guid criadoPorId)
        => await _marcaCore.CriarAsync(requestDto, criadoPorId);

    public async Task<MarcaResponseDto> ObterPorIdAsync(int id)
        => await _marcaCore.ObterPorIdAsync(id) ?? throw new Exception("Marca não encontrada.");

    public async Task<IEnumerable<MarcaResponseDto>> ListarAsync(MarcaListarRequestDto? requestDto = null)
        => await _marcaCore.ListarAsync(requestDto);
}
