namespace PagueiBaratoApi.Domain.Dtos.Categoria;

public record CategoriaResponseDto
{
    public int Id { get; init; }
    public string Nome { get; init; }
    public string Descricao { get; init; }
    public DateTime CriadoEm { get; init; }
    public Guid CriadoPorId { get; init; }
}
