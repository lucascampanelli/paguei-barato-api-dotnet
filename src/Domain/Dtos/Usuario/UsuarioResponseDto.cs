namespace PagueiBaratoApi.Domain.Dtos.Usuario;

public record class UsuarioResponseDto
{
    public Guid Id { get; init; }
    public string Nome { get; init; }
    public string Email { get; init; }
    public string? Cep { get; init; }
    public DateTime CriadoEm { get; init; }
}
