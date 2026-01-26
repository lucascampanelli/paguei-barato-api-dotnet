using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Marca;
using PagueiBaratoApi.Infrastructure.Repository.Interface;

namespace PagueiBaratoApi.Application;

public class MarcaApplication : IMarcaApplication
{
    public readonly IMarcaRepository _marcaRepository;

    public MarcaApplication(IMarcaRepository marcaRepository)
    {
        _marcaRepository = marcaRepository;
    }

    public async Task<MarcaResponseDto> CriarAsync(MarcaCriarRequestDto requestDto, Guid criadoPorId)
    {
        return await _marcaRepository.CriarAsync(requestDto, criadoPorId);
    }

    public async Task<MarcaResponseDto> ObterPorIdAsync(int id)
    {
        var marca =  await _marcaRepository.ObterPorIdAsync(id);
        if (marca == null)
            throw new Exception("Marca não encontrada.");
        return marca;
    }

    public async Task<IEnumerable<MarcaResponseDto>> ListarAsync(MarcaListarRequestDto? requestDto = null)
    {
        return await _marcaRepository.ListarAsync(requestDto);
    }
}
