using Microsoft.AspNetCore.Identity;
using PagueiBaratoApi.Core.Interfaces;
using PagueiBaratoApi.Domain.Entities;

namespace PagueiBaratoApi.Core;

public class SenhaCore : ISenhaCore
{
    private readonly IPasswordHasher<Usuario> _passwordHasher;

    public SenhaCore(IPasswordHasher<Usuario> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string AplicarHashSenha(string senha)
    {
        var usuarioDummy = new Usuario();
        return _passwordHasher.HashPassword(usuarioDummy, senha);
    }

    public bool VerificarSenha(string senhaHash, string senha)
    {
        var usuarioDummy = new Usuario();
        var resultado = _passwordHasher.VerifyHashedPassword(usuarioDummy, senhaHash, senha);
        return resultado != PasswordVerificationResult.Failed;
    }
}