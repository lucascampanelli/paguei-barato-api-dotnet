namespace PagueiBaratoApi.Domain.Entities;

public class Loja
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public IEnumerable<Ramo> Ramos { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }
    public DateTime CriadoEm { get; set; }
    public Guid CriadoPorId { get; set; }
    public Usuario CriadoPor { get; set; }
}
