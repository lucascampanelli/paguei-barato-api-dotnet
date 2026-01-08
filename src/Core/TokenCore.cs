using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using PagueiBaratoApi.Infrastructure.Repository.Interface;
using PagueiBaratoApi.Domain.Dtos.RefreshToken;

namespace PagueiBaratoApi.Core;

public class TokenCore : ITokenCore
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IOptions<Secrets> _secrets;

    public TokenCore(IRefreshTokenRepository refreshTokenRepository, IOptions<Secrets> secrets)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _secrets = secrets;
    }
    public string GerarToken(Guid idUsuario)
    {
        var issuer = _secrets.Value.Token.Issuer;
        var secretKey = _secrets.Value.Token.Key;
        var audience = _secrets.Value.Token.Audience;
        var minutosParaExpirar = _secrets.Value.Token.MinutosParaExpirar;

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
    {
        return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }

    public async Task<RefreshTokenDto?> ObterRefreshTokenPorTokenAsync(string refreshToken)
    {
        return await _refreshTokenRepository.ObterPorTokenAsync(refreshToken);
    }

    public async Task<RefreshTokenDto> SalvarRefreshTokenAsync(RefreshTokenDto refreshTokenDto)
    {
        return await _refreshTokenRepository.SalvarAsync(refreshTokenDto);
    }

    public async Task RemoverTodosRefreshTokensDoUsuarioAsync(Guid usuarioId)
    {
        await _refreshTokenRepository.RemoverTodosDoUsuarioAsync(usuarioId);
    }
}
