using PagueiBaratoApi.Domain.Dtos.Usuario;
using PagueiBaratoApi.Domain.Mappers.Usuario;
using PagueiBaratoApi.Domain.Repository;
using PagueiBaratoApi.Infrastructure.Setup;

namespace PagueiBaratoApi.Infrastructure.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DatabaseContext _dbContext;

    public UsuarioRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UsuarioResponseDto> CriarAsync(UsuarioCriarRequestDto requestDto)
    {
        var usuarioEntity = requestDto.ToEntity();
        await _dbContext.Usuarios.AddAsync(usuarioEntity);
        await _dbContext.SaveChangesAsync();
        return usuarioEntity.ToResponseDto();
    }
}
