using PagueiBaratoApi.Domain.Applications;
using PagueiBaratoApi.Domain.Dtos.Usuario;
using PagueiBaratoApi.Domain.Repository;

namespace PagueiBaratoApi.Application;

public class UsuarioApplication : IUsuarioApplication
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioApplication(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public Task<UsuarioResponseDto> CriarAsync(UsuarioCriarRequestDto requestDto)
    {
        return _usuarioRepository.CriarAsync(requestDto);
    }
}
