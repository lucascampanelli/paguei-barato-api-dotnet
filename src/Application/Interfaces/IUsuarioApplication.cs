using PagueiBaratoApi.Domain.Dtos.Usuario;

namespace PagueiBaratoApi.Application.Interfaces;

public interface IUsuarioApplication
{
    Task<UsuarioResponseDto> CadastrarAsync(UsuarioCadastrarRequestDto requestDto);
    Task<UsuarioAutenticarResponseDto> AutenticarAsync(UsuarioAutenticarRequestDto requestDto);
}
