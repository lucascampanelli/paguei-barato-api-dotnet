using PagueiBaratoApi.Domain.Dtos.Usuario;

namespace PagueiBaratoApi.Domain.Applications;

public interface IUsuarioApplication
{
    Task<UsuarioResponseDto> CriarAsync(UsuarioCriarRequestDto requestDto);
}
