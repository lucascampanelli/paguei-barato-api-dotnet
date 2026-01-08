namespace PagueiBaratoApi.Domain.Dtos.RefreshToken;

public record class RefreshTokenDto
{
    public int Id { get; set; }
    public string Token { get; set; }
    public DateTime Expiracao { get; set; }
    public Guid UsuarioId { get; set; }
}
