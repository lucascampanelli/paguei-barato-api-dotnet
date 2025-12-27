namespace PagueiBaratoApi.Domain.Entities;

public class Marca
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime CriadoEm { get; set; }
    public Guid CriadoPorId { get; set; }
    public Usuario CriadoPor { get; set; }
}
