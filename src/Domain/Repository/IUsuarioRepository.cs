using PagueiBaratoApi.Domain.Dtos.Usuario;

namespace PagueiBaratoApi.Domain.Repository;

public interface IUsuarioRepository
{
    Task<UsuarioResponseDto> CriarAsync(UsuarioCriarRequestDto requestDto);
}
