using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Dtos.RefreshToken;
using PagueiBaratoApi.Domain.Options;
using PagueiBaratoApi.Infrastructure.Repository.Interface;

namespace PagueiBaratoApi.Core;

public class TokenCore : ITokenCore
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IOptions<AuthTokenOptions> _authTokenOptions;

    public TokenCore(IRefreshTokenRepository refreshTokenRepository, IOptions<AuthTokenOptions> authTokenOptions)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _authTokenOptions = authTokenOptions;
    }
    public string GerarToken(Guid idUsuario)
    {
        var issuer = _authTokenOptions.Value.Issuer;
        var secretKey = _authTokenOptions.Value.Key;
        var audience = _authTokenOptions.Value.Audience;
        var minutosParaExpirar = _authTokenOptions.Value.MinutosParaExpirar;

        var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(JwtRegisteredClaimNames.Sub, idUsuario.ToString())
            ]),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = signingCredentials,
            Expires = DateTime.UtcNow.AddMinutes(minutosParaExpirar),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GerarRefreshToken()
        => Convert.ToBase64String(Guid.NewGuid().ToByteArray());

    public async Task<RefreshTokenDto?> ObterRefreshTokenPorTokenAsync(string refreshToken)
        => await _refreshTokenRepository.ObterPorTokenAsync(refreshToken);

    public async Task<RefreshTokenDto> SalvarRefreshTokenAsync(RefreshTokenDto refreshTokenDto)
        => await _refreshTokenRepository.SalvarAsync(refreshTokenDto);

    public async Task RemoverTodosRefreshTokensDoUsuarioAsync(Guid usuarioId)
        => await _refreshTokenRepository.RemoverTodosDoUsuarioAsync(usuarioId);
}
