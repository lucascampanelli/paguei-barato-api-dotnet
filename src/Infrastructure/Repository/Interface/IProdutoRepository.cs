using PagueiBaratoApi.Domain.Dtos.Produto;

namespace PagueiBaratoApi.Infrastructure.Repository.Interface;

public interface IProdutoRepository
{
    Task<ProdutoResponseDto?> ObterPorIdAsync(int id);
}