namespace PagueiBaratoApi.Domain.Dtos.Usuario;

public record class UsuarioObterPorEmailDto
{
    public Guid Id { get; init; }
    public required string Nome { get; init; }
    public required string Email { get; init; }
    public required string Senha { get; init; }
    public string? Cep { get; init; }
    public required DateTime CriadoEm { get; init; }
}
