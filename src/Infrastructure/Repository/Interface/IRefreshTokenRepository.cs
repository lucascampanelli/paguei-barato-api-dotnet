using PagueiBaratoApi.Domain.Dtos.RefreshToken;

namespace PagueiBaratoApi.Infrastructure.Repository.Interface;

public interface IRefreshTokenRepository
{
    Task<RefreshTokenDto?> ObterPorTokenAsync(string refreshToken);
    Task<RefreshTokenDto> SalvarAsync(RefreshTokenDto refreshTokenDto);
    Task RemoverTodosDoUsuarioAsync(Guid usuarioId);
}
