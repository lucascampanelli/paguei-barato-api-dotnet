using PagueiBaratoApi.Domain.Dtos.Usuario;

namespace PagueiBaratoApi.Core.Interfaces;

public interface IUsuarioCore
{
    Task<UsuarioResponseDto> CriarAsync(UsuarioCadastrarRequestDto requestDto);
}
