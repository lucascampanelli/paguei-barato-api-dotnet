using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Usuario;

namespace PagueiBaratoApi.Application;

public class UsuarioApplication : IUsuarioApplication
{
    private readonly IUsuarioCore _usuarioCore;
    private readonly ISenhaCore _senhaCore;

    public UsuarioApplication(IUsuarioCore usuarioCore, ISenhaCore senhaCore)
    {
        _usuarioCore = usuarioCore;
        _senhaCore = senhaCore;
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

        return new UsuarioAutenticarResponseDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            CriadoEm = usuario.CriadoEm,
            Token = "token",
            RefreshToken = "refresh_token"
        };
    }
}
