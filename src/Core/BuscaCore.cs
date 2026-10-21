using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Busca;
using PagueiBaratoApi.Domain.Extensions;
using PagueiBaratoApi.Infrastructure.Repository.Interfaces;

namespace PagueiBaratoApi.Core;

public class BuscaCore : IBuscaCore
{
    private readonly IBuscaRepository _buscaRepository;

    public BuscaCore(IBuscaRepository buscaRepository)
    {
        _buscaRepository = buscaRepository;
    }

    public async Task<BuscaCatalogoResponseDto> BuscarAsync(BuscaCatalogoRequestDto requestDto)
    {
        var normalizedRequestDto = new BuscaCatalogoRequestDto
        {
            Termo = requestDto.Termo.TrimIfNotNullOrWhiteSpace(),
            Tipo = requestDto.Tipo.TrimIfNotNullOrWhiteSpace(),
            Categoria = requestDto.Categoria.TrimIfNotNullOrWhiteSpace(),
            Ramo = requestDto.Ramo.TrimIfNotNullOrWhiteSpace(),
            Marca = requestDto.Marca.TrimIfNotNullOrWhiteSpace(),
            Cidade = requestDto.Cidade.TrimIfNotNullOrWhiteSpace(),
            Estado = requestDto.Estado.TrimIfNotNullOrWhiteSpace(),
            Bairro = requestDto.Bairro.TrimIfNotNullOrWhiteSpace(),
            Pagina = Math.Max(requestDto.Pagina, 1),
            TamanhoPagina = Math.Clamp(requestDto.TamanhoPagina, 1, 100)
        };
        return await _buscaRepository.BuscarAsync(normalizedRequestDto);
    }
}
