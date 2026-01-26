namespace PagueiBaratoApi.Domain.Dtos.Marca;

public class MarcaResponseDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime CriadoEm { get; set; }
    public Guid CriadoPorId { get; set; }
}
