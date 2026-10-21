namespace PagueiBaratoApi.Domain.Entities.Views;

public class BuscaFacetaView
{
    public string Faceta { get; set; } = string.Empty;
    public string Valor { get; set; } = string.Empty;
    public int Total { get; set; }
}
