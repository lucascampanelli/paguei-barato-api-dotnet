using Microsoft.EntityFrameworkCore;
using PagueiBaratoApi.Domain.Dtos.RefreshToken;
using PagueiBaratoApi.Domain.Mappers.RefreshToken;
using PagueiBaratoApi.Infrastructure.Repository.Interface;
using PagueiBaratoApi.Infrastructure.Setup;

namespace PagueiBaratoApi.Infrastructure.Repository;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly DatabaseContext _dbContext;

    public RefreshTokenRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RefreshTokenDto?> ObterPorTokenAsync(string refreshToken)
    {
        var refreshTokenEntity = await _dbContext.RefreshTokens
            .FirstOrDefaultAsync(rt => rt.Token == refreshToken);

        if (refreshTokenEntity == null)
            return null;

        return refreshTokenEntity.ToDto();
    }

    public async Task<RefreshTokenDto> SalvarAsync(RefreshTokenDto refreshTokenDto)
    {
        var refreshTokenEntity = refreshTokenDto.ToEntity();
        await _dbContext.RefreshTokens.AddAsync(refreshTokenEntity);
        await _dbContext.SaveChangesAsync();
        return refreshTokenEntity.ToDto();
    }

    public async Task RemoverTodosDoUsuarioAsync(Guid usuarioId)
    {
        var refreshTokens = _dbContext.RefreshTokens
            .Where(rt => rt.UsuarioId == usuarioId);

        _dbContext.RefreshTokens.RemoveRange(refreshTokens);
        await _dbContext.SaveChangesAsync();
    }
}
