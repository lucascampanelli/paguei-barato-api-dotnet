using Microsoft.EntityFrameworkCore;
using PagueiBaratoApi.Domain.Dtos.Loja;
using PagueiBaratoApi.Domain.Mappers.Loja;
using PagueiBaratoApi.Infrastructure.Repository.Interfaces;
using PagueiBaratoApi.Infrastructure.Setup;

namespace PagueiBaratoApi.Infrastructure.Repository;

public class LojaRepository : ILojaRepository
{
    private readonly DatabaseContext _dbContext;

    public LojaRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LojaDetalhesDto?> ObterPorIdAsync(int id)
    {
        var loja = await _dbContext.Lojas
            .Include(x => x.Ramos)
            .FirstOrDefaultAsync(x => x.Id == id);

        return loja?.ToDetalhesDto();
    }
}
