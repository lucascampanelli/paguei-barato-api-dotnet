
using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Produto;

namespace PagueiBaratoApi.Application;

public class ProdutoApplication : IProdutoApplication
{
    private readonly IProdutoCore _produtoCore;

    public ProdutoApplication(IProdutoCore produtoCore)
    {
        _produtoCore = produtoCore;
    }

    public async Task<ProdutoResponseDto> ObterPorIdAsync(int id)
        => await _produtoCore.ObterPorIdAsync(id) ?? throw new Exception("Produto não encontrado.");
}
