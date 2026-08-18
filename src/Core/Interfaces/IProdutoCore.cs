using PagueiBaratoApi.Domain.Dtos.Produto;

namespace PagueiBaratoApi.Core.Interfaces;

public interface IProdutoCore
{
    Task<ProdutoResponseDto?> ObterPorIdAsync(int id);
}
