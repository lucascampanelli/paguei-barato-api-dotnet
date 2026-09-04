using PagueiBaratoApi.Domain.Dtos.Produto;

namespace PagueiBaratoApi.Core.Interfaces;

public interface IProdutoCore
{
    Task<ProdutoDetalhesDto?> ObterPorIdAsync(int id);
}
