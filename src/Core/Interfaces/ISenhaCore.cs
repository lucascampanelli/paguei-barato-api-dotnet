namespace PagueiBaratoApi.Core.Interfaces;

public interface ISenhaCore
{
    string AplicarHashSenha(string senha);
    bool VerificarSenha(string senhaHash, string senha);
}
