namespace PagueiBaratoApi.Domain.Entidades;

public class Relato
{
    public int Id { get; set; }
    public int EstoqueId { get; set; }
    public Estoque Estoque { get; set; }
    public decimal Preco { get; set; }
    public DateTime CriadoEm { get; set; }
    public Guid CriadoPorId { get; set; }
    public Usuario CriadoPor { get; set; }
}
