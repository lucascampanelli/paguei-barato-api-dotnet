namespace PagueiBaratoApi.Domain.Entidades;

public class Marca
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime CriadoEm { get; set; }
    public int CriadoPorId { get; set; }
    public Usuario CriadoPor { get; set; }
}
