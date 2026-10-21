using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Busca;

namespace PagueiBaratoApi.Application;

public class BuscaApplication : IBuscaApplication
{
    private readonly IBuscaCore _buscaCore;

    public BuscaApplication(IBuscaCore buscaCore)
    {
        _buscaCore = buscaCore;
    }

    public async Task<BuscaCatalogoResponseDto> BuscarAsync(BuscaCatalogoRequestDto requestDto)
    {
        return await _buscaCore.BuscarAsync(new BuscaCatalogoRequestDto
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
    }
}
