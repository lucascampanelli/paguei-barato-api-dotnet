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
}
