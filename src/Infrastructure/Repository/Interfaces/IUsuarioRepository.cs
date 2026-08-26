using PagueiBaratoApi.Domain.Dtos.Usuario;

namespace PagueiBaratoApi.Infrastructure.Repository.Interfaces;

public interface IUsuarioRepository
{
    Task<UsuarioResponseDto> CriarAsync(UsuarioCadastrarRequestDto requestDto);
    Task<UsuarioObterPorEmailDto?> ObterPorEmailAsync(string email);
}
