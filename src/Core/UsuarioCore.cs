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

    public async Task<UsuarioResponseDto> CriarAsync(UsuarioCadastrarRequestDto requestDto)
        => await _usuarioRepository.CriarAsync(requestDto);

    public async Task<UsuarioObterPorEmailDto?> ObterPorEmailAsync(string email)
        => await _usuarioRepository.ObterPorEmailAsync(email);
}
