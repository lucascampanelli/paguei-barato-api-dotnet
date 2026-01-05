namespace PagueiBaratoApi.Domain.Dtos.Usuario;

public record class UsuarioAutenticarRequestDto
{
    public required string Email { get; init; }
    public required string Senha { get; init; }
}
