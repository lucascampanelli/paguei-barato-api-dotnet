using PagueiBaratoApi.Domain.Dtos.Usuario;

namespace PagueiBaratoApi.Domain.Mappers.Usuario;

public static class UsuarioMapper
{
    public static Entities.Usuario ToEntity(this UsuarioCriarRequestDto usuario)
    {
        return new Entities.Usuario
        {
            Nome = usuario.Nome,
            Email = usuario.Email,
            Senha = usuario.Senha,
            Cep = usuario.Cep
        };
    }

    public static UsuarioResponseDto ToResponseDto(this Entities.Usuario usuario)
    {
        return new UsuarioResponseDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            Cep = usuario.Cep,
            CriadoEm = usuario.CriadoEm
        };
    }
}
