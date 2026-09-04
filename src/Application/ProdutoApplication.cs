
using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Produto;
using PagueiBaratoApi.Domain.Mappers.Produto;
using PagueiBaratoApi.Infrastructure.Adapters.Interfaces;

namespace PagueiBaratoApi.Application;

public class ProdutoApplication : IProdutoApplication
{
    private readonly IProdutoCore _produtoCore;
    private readonly IImagensAdapter _imagensAdapter;

    public ProdutoApplication(IProdutoCore produtoCore, IImagensAdapter imagensAdapter)
    {
        _produtoCore = produtoCore;
        _imagensAdapter = imagensAdapter;
    }

    public async Task<ProdutoResponseDto> ObterPorIdAsync(int id)
    {
        var produto = await _produtoCore.ObterPorIdAsync(id) ?? throw new Exception("Produto não encontrado.");
        var urlImagem = await _imagensAdapter.ResolverUrlAsync(produto.ImagemPath);
        var produtoResponseDto = produto.ToResponseDto(urlImagem!);
        return produtoResponseDto;
    }
}
