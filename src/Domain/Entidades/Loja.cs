namespace PagueiBaratoApi.Domain.Entidades;

public class Loja
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public IEnumerable<Ramo> Ramos { get; set; }
}
