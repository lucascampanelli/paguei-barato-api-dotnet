namespace PagueiBaratoApi.Domain.Entidades;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime CriadoEm { get; set; }
    public int CriadoPorId { get; set; }
    public Usuario CriadoPor { get; set; }
}
