using Microsoft.EntityFrameworkCore;
using PagueiBaratoApi.Domain.Dtos.Marca;
using PagueiBaratoApi.Domain.Mappers.Marca;
using PagueiBaratoApi.Infrastructure.Repository.Interfaces;
using PagueiBaratoApi.Infrastructure.Setup;

namespace PagueiBaratoApi.Infrastructure.Repository;

public class MarcaRepository : IMarcaRepository
{
    private readonly DatabaseContext _dbContext;

    public MarcaRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MarcaResponseDto> CriarAsync(MarcaCriarRequestDto marcaDto, Guid criadoPorId)
    {
        var marcaEntity = marcaDto.ToEntity(criadoPorId);
        await _dbContext.Marcas.AddAsync(marcaEntity);
        await _dbContext.SaveChangesAsync();
        return marcaEntity.ToResponseDto();
    }

    public async Task<IEnumerable<MarcaResponseDto>> ListarAsync(MarcaListarRequestDto? requestDto)
    {
        var query = _dbContext.Marcas.AsNoTracking();

        if (!string.IsNullOrEmpty(requestDto?.Nome))
            query = query.Where(m => EF.Functions.ILike(m.Nome, $"%{requestDto.Nome}%"));
        
        var results = await query.Select(m => m.ToResponseDto()).ToListAsync();
        return results;
    }

    public async Task<MarcaResponseDto?> ObterPorIdAsync(int id)
    {
        var marcaEntity = await _dbContext.Marcas
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (marcaEntity == null)
            return null;

        return marcaEntity.ToResponseDto();
    }
}
