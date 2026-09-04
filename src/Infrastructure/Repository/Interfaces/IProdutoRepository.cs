using PagueiBaratoApi.Domain.Dtos.Produto;

namespace PagueiBaratoApi.Infrastructure.Repository.Interfaces;

public interface IProdutoRepository
{
    Task<ProdutoDetalhesDto?> ObterPorIdAsync(int id);
}