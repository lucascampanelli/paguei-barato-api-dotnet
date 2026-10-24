using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Loja;
using PagueiBaratoApi.Domain.Mappers.Loja;
using PagueiBaratoApi.Infrastructure.Adapters.Interfaces;

namespace PagueiBaratoApi.Application;

public class LojaApplication : ILojaApplication
{
    private readonly ILojaCore _lojaCore;
    private readonly IImagensAdapter _imagensAdapter;

    public LojaApplication(ILojaCore lojaCore, IImagensAdapter imagensAdapter)
    {
        _lojaCore = lojaCore;
        _imagensAdapter = imagensAdapter;
    }

    public async Task<LojaResponseDto> ObterPorIdAsync(int id)
    {
        var loja = await _lojaCore.ObterPorIdAsync(id)
            ?? throw new Exception("Loja nao encontrada.");
        var imagemUrl = await _imagensAdapter.ResolverUrlAsync(loja.ImagemPath);
        return loja.ToResponseDto(imagemUrl);
    }
}
