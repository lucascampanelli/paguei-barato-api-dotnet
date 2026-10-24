using PagueiBaratoApi.Domain.Dtos.Ramo;

namespace PagueiBaratoApi.Domain.Dtos.Loja;

public record LojaDetalhesDto
{
    public int Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public IEnumerable<RamoResponseDto> Ramos { get; init; } = Enumerable.Empty<RamoResponseDto>();
    public string Logradouro { get; init; } = string.Empty;
    public string Numero { get; init; } = string.Empty;
    public string Bairro { get; init; } = string.Empty;
    public string Cidade { get; init; } = string.Empty;
    public string Estado { get; init; } = string.Empty;
    public string Cep { get; init; } = string.Empty;
    public string ImagemPath { get; init; } = string.Empty;
    public DateTime CriadoEm { get; init; }
}
