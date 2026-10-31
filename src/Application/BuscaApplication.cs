using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Busca;
using PagueiBaratoApi.Infrastructure.Adapters.Interfaces;

namespace PagueiBaratoApi.Application;

public class BuscaApplication : IBuscaApplication
{
    private readonly IBuscaCore _buscaCore;
    private readonly IImagensAdapter _imagensAdapter;

    public BuscaApplication(IBuscaCore buscaCore, IImagensAdapter imagensAdapter)
    {
        _buscaCore = buscaCore;
        _imagensAdapter = imagensAdapter;
    }

    public async Task<BuscaCatalogoResponseDto> BuscarAsync(BuscaCatalogoRequestDto requestDto)
    {
        var resposta = await _buscaCore.BuscarAsync(new BuscaCatalogoRequestDto
        {
            Termo = requestDto.Termo,
            Tipo = requestDto.Tipo,
            Categoria = requestDto.Categoria,
            Ramo = requestDto.Ramo,
            Marca = requestDto.Marca,
            Cidade = requestDto.Cidade,
            Estado = requestDto.Estado,
            Bairro = requestDto.Bairro,
            Pagina = requestDto.Pagina,
            TamanhoPagina = requestDto.TamanhoPagina
        });

        var itens = await Task.WhenAll(resposta.Itens.Select(async item => new BuscaCatalogoItemResponseDto
        {
            ItemId = item.ItemId,
            Tipo = item.Tipo,
            Nome = item.Nome,
            ImagemUrl = await _imagensAdapter.ResolverUrlAsync(item.ImagemPath)
        }));

        return new BuscaCatalogoResponseDto
        {
            Itens = itens,
            Facetas = resposta.Facetas,
            Pagina = resposta.Pagina,
            TamanhoPagina = resposta.TamanhoPagina,
            TotalItens = resposta.TotalItens
        };
    }
}
