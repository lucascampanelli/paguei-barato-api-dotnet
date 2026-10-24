using PagueiBaratoApi.Domain.Dtos.Loja;

namespace PagueiBaratoApi.Core.Interfaces;

public interface ILojaCore
{
    Task<LojaDetalhesDto?> ObterPorIdAsync(int id);
}
