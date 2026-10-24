using PagueiBaratoApi.Domain.Dtos.Loja;

namespace PagueiBaratoApi.Infrastructure.Repository.Interfaces;

public interface ILojaRepository
{
    Task<LojaDetalhesDto?> ObterPorIdAsync(int id);
}
