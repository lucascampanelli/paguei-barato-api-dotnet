using PagueiBaratoApi.Domain.Dtos.Produto;

namespace PagueiBaratoApi.Application.Interfaces;

public interface IProdutoApplication
{
    Task<ProdutoResponseDto> ObterPorIdAsync(int id);
}
