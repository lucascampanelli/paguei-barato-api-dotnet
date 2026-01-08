using PagueiBaratoApi.Domain.Dtos.RefreshToken;

namespace PagueiBaratoApi.Core.Interfaces;

public interface ITokenCore
{
    public string GerarToken(Guid idUsuario);
    public string GerarRefreshToken();
    public Task<RefreshTokenDto?> ObterRefreshTokenPorTokenAsync(string refreshToken);
    public Task<RefreshTokenDto> SalvarRefreshTokenAsync(RefreshTokenDto refreshTokenDto);
    public Task RemoverTodosRefreshTokensDoUsuarioAsync(Guid usuarioId);
}
