namespace PagueiBaratoApi.Domain.Entities;

public class RefreshToken
{
    public int Id { get; set; }
    public string Token { get; set; }
    public DateTime Expiracao { get; set; }
    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}
