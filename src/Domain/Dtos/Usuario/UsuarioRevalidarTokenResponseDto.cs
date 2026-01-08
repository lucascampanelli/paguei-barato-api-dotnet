namespace PagueiBaratoApi.Domain.Dtos.Usuario;

public record class UsuarioRevalidarTokenResponseDto
{
    public string Token { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
}
