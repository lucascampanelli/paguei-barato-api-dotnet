using PagueiBaratoApi.Domain.Dtos.Usuario;

namespace PagueiBaratoApi.Infrastructure.Repository.Interface;

public interface IUsuarioRepository
{
    Task<UsuarioResponseDto> CriarAsync(UsuarioCadastrarRequestDto requestDto);
}
