namespace PagueiBaratoApi.Domain.Dtos.Ramo;

public record RamoResponseDto
{
    public int Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public string Descricao { get; init; } = string.Empty;
}
