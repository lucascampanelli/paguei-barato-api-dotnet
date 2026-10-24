using PagueiBaratoApi.Domain.Dtos.Loja;

namespace PagueiBaratoApi.Application.Interfaces;

public interface ILojaApplication
{
    Task<LojaResponseDto> ObterPorIdAsync(int id);
}
