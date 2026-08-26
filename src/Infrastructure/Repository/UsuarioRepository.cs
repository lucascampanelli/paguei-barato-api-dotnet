using Microsoft.EntityFrameworkCore;
using PagueiBaratoApi.Domain.Dtos.Usuario;
using PagueiBaratoApi.Domain.Mappers.Usuario;
using PagueiBaratoApi.Infrastructure.Repository.Interfaces;
using PagueiBaratoApi.Infrastructure.Setup;

namespace PagueiBaratoApi.Infrastructure.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DatabaseContext _dbContext;

    public UsuarioRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UsuarioResponseDto> CriarAsync(UsuarioCadastrarRequestDto requestDto)
    {
        var usuarioEntity = requestDto.ToEntity();
        await _dbContext.Usuarios.AddAsync(usuarioEntity);
        await _dbContext.SaveChangesAsync();
        return usuarioEntity.ToResponseDto();
    }

    public async Task<UsuarioObterPorEmailDto?> ObterPorEmailAsync(string email)
    {
        var usuarioEntity = await _dbContext.Usuarios
            .FirstOrDefaultAsync(u => u.Email == email);

        if (usuarioEntity == null)
            return null;

        return usuarioEntity.ToObterPorEmailDto();
    }
}
