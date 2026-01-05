namespace PagueiBaratoApi.Domain.Dtos.Usuario;

public record class UsuarioAutenticarResponseDto
{
    public Guid Id { get; init; }
    public required string Nome { get; init; }
    public required string Email { get; init; }
    public required DateTime CriadoEm { get; init; }
    public required string Token { get; init; }
    public required string RefreshToken { get; init; }
}
