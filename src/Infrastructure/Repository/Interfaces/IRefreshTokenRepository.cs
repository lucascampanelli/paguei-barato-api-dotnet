using PagueiBaratoApi.Domain.Dtos.RefreshToken;

namespace PagueiBaratoApi.Infrastructure.Repository.Interfaces;

public interface IRefreshTokenRepository
{
    Task<RefreshTokenDto?> ObterPorTokenAsync(string refreshToken);
    Task<RefreshTokenDto> SalvarAsync(RefreshTokenDto refreshTokenDto);
    Task RemoverTodosDoUsuarioAsync(Guid usuarioId);
}
