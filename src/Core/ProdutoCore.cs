
using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Produto;
using PagueiBaratoApi.Infrastructure.Repository.Interfaces;

namespace PagueiBaratoApi.Core;

public class ProdutoCore : IProdutoCore
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoCore(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ProdutoResponseDto?> ObterPorIdAsync(int id)
        => await _produtoRepository.ObterPorIdAsync(id);
}
