namespace PagueiBaratoApi.Core.Interfaces;

public interface ITokenCore
{
    public string GerarToken(Guid idUsuario);
    public string GerarRefreshToken();
}
