namespace PagueiBaratoApi.Domain.Entities.Views;

public class BuscaCatalogoView
{
    public int ItemId { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string? ImagemPath { get; set; }
}
