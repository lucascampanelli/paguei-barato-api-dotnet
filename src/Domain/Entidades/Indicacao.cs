namespace PagueiBaratoApi.Domain.Entidades;

public class Indicacao
{
    public int Id { get; set; }
    public int EstoqueId { get; set; }
    public Estoque Estoque { get; set; }
    public decimal Preco { get; set; }
    public DateTime CriadoEm { get; set; }
    public int CriadoPorId { get; set; }
    public Usuario CriadoPor { get; set; }
}
