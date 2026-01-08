using Microsoft.Extensions.Options;
using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Dtos.RefreshToken;
using PagueiBaratoApi.Domain.Dtos.Usuario;
using PagueiBaratoApi.Domain.Options;

namespace PagueiBaratoApi.Application;

public class UsuarioApplication : IUsuarioApplication
{
    private readonly IUsuarioCore _usuarioCore;
    private readonly ISenhaCore _senhaCore;
    private readonly ITokenCore _tokenCore;
    private readonly IOptions<Secrets> _secrets;

    public UsuarioApplication(IUsuarioCore usuarioCore, ISenhaCore senhaCore, ITokenCore tokenCore, IOptions<Secrets> secrets)
    {
        _usuarioCore = usuarioCore;
        _senhaCore = senhaCore;
        _tokenCore = tokenCore;
        _secrets = secrets;
    }

    public Task<UsuarioResponseDto> CadastrarAsync(UsuarioCadastrarRequestDto requestDto)
    {
        var emailLowercase = requestDto.Email.ToLower();
        var senhaHash = _senhaCore.AplicarHashSenha(requestDto.Senha);

        var usuarioDto = requestDto with
        {
            Email = emailLowercase,
            Senha = senhaHash
        };

        return _usuarioCore.CriarAsync(usuarioDto);
    }

    public async Task<UsuarioAutenticarResponseDto> AutenticarAsync(UsuarioAutenticarRequestDto requestDto)
    {
        var emailLowercase = requestDto.Email.ToLower();

        var usuario = await _usuarioCore.ObterPorEmailAsync(emailLowercase);
        if (usuario == null)
            throw new UnauthorizedAccessException();

        var senhaValida = _senhaCore.VerificarSenha(usuario.Senha, requestDto.Senha);
        if (!senhaValida)
            throw new UnauthorizedAccessException();

        var token = _tokenCore.GerarToken(usuario.Id);
        var refreshToken = _tokenCore.GerarRefreshToken();

        await _tokenCore.RemoverTodosRefreshTokensDoUsuarioAsync(usuario.Id);

        var diasParaExpirarRefreshToken = _secrets.Value.Token.DiasParaExpirarRefreshToken;
        var refreshTokenDto = new RefreshTokenDto
        {
            Token = refreshToken,
            UsuarioId = usuario.Id,
            Expiracao = DateTime.UtcNow.AddDays(diasParaExpirarRefreshToken)
        };

        await _tokenCore.SalvarRefreshTokenAsync(refreshTokenDto);

        return new UsuarioAutenticarResponseDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            CriadoEm = usuario.CriadoEm,
            Token = token,
            RefreshToken = refreshToken
        };
    }

    public async Task<UsuarioRevalidarTokenResponseDto> RevalidarTokenAsync(UsuarioRevalidarTokenRequestDto requestDto)
    {
        var refreshTokenDto = await _tokenCore.ObterRefreshTokenPorTokenAsync(requestDto.RefreshToken);
        if (refreshTokenDto == null || refreshTokenDto.Expiracao < DateTime.UtcNow)
            throw new UnauthorizedAccessException();

        var newToken = _tokenCore.GerarToken(refreshTokenDto.UsuarioId);
        var newRefreshToken = _tokenCore.GerarRefreshToken();

        await _tokenCore.RemoverTodosRefreshTokensDoUsuarioAsync(refreshTokenDto.UsuarioId);

        var diasParaExpirarRefreshToken = _secrets.Value.Token.DiasParaExpirarRefreshToken;
        var newRefreshTokenDto = new RefreshTokenDto
        {
            Token = newRefreshToken,
            UsuarioId = refreshTokenDto.UsuarioId,
            Expiracao = DateTime.UtcNow.AddDays(diasParaExpirarRefreshToken)
        };

        await _tokenCore.SalvarRefreshTokenAsync(newRefreshTokenDto);

        return new UsuarioRevalidarTokenResponseDto
        {
            Token = newToken,
            RefreshToken = newRefreshToken
        };
    }
}
