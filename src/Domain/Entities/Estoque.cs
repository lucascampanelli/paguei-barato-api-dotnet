namespace PagueiBaratoApi.Domain.Entities;

public class Estoque
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; }
    public int LojaId { get; set; }
    public Loja Loja { get; set; }
    public DateTime CriadoEm { get; set; }
    public Guid CriadoPorId { get; set; }
    public Usuario CriadoPor { get; set; }
}
