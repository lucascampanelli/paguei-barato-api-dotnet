using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Loja;
using PagueiBaratoApi.Infrastructure.Repository.Interfaces;

namespace PagueiBaratoApi.Core;

public class LojaCore : ILojaCore
{
    private readonly ILojaRepository _lojaRepository;

    public LojaCore(ILojaRepository lojaRepository)
    {
        _lojaRepository = lojaRepository;
    }

    public async Task<LojaDetalhesDto?> ObterPorIdAsync(int id)
        => await _lojaRepository.ObterPorIdAsync(id);
}
