namespace PagueiBaratoApi.Domain.Dtos.Usuario;

public record class UsuarioRevalidarTokenRequestDto
{
    public string RefreshToken { get; init; } = string.Empty;
}
