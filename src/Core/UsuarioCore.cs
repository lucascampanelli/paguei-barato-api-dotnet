using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Usuario;
using PagueiBaratoApi.Infrastructure.Repository.Interface;

namespace PagueiBaratoApi.Core;

public class UsuarioCore : IUsuarioCore
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioCore(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public Task<UsuarioResponseDto> CriarAsync(UsuarioCadastrarRequestDto requestDto)
    {
        return  _usuarioRepository.CriarAsync(requestDto);
    }

    public Task<UsuarioObterPorEmailDto?> ObterPorEmailAsync(string email)
    {
        return _usuarioRepository.ObterPorEmailAsync(email);
    }
}
