namespace PagueiBaratoApi.Domain.Entidades;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int MarcaId { get; set; }
    public Marca Marca { get; set; }
    public IEnumerable<Categoria> Categorias { get; set; }
    public Dictionary<string, string> Atributos { get; set; }
    public DateTime CriadoEm { get; set; }
    public int CriadoPorId { get; set; }
    public Usuario CriadoPor { get; set; }
}
