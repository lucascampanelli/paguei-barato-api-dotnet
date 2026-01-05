using PagueiBaratoApi.Core.Interfaces;

namespace PagueiBaratoApi.Core;

public class TokenCore : ITokenCore
{
    public string GerarToken(Guid idUsuario)
    {
        // Lógica para gerar token
        return "token";
    }

    public string GerarRefreshToken()
    {
        // Lógica para gerar refresh token
        return "refreshToken";
    }
}
