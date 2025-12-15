namespace PagueiBaratoApi.Domain.Entidades;

public class Indicacao
{
    public int Id { get; set; }
    public int EstoqueId { get; set; }
    public Estoque Estoque { get; set; }
    public decimal Preco { get; set; }
    public DateTime IndicadoEm { get; set; }
    public int IndicadoPorId { get; set; }
    public Usuario IndicadoPor { get; set; }
}
