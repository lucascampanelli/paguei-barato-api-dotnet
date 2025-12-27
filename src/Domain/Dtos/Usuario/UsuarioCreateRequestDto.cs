namespace PagueiBaratoApi.Domain.Dtos.Usuario;

public record class UsuarioCriarRequestDto
{
    public string Nome { get; init; }
    public string Email { get; init; }
    public string Senha { get; init; }
    public string? Cep { get; init; }
}
