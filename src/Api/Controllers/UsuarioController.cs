using Microsoft.AspNetCore.Mvc;
using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Usuario;

namespace PagueiBaratoApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioApplication _usuarioApplication;

    public UsuarioController(IUsuarioApplication usuarioApplication)
    {
        _usuarioApplication = usuarioApplication;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarAsync([FromBody] UsuarioCadastrarRequestDto requestDto)
    {
        var result = await _usuarioApplication.CadastrarAsync(requestDto);
        return CreatedAtAction(nameof(CadastrarAsync), result);
    }

    [HttpPost("autenticar")]
    public async Task<IActionResult> AutenticarAsync([FromBody] UsuarioAutenticarRequestDto requestDto)
    {
        var result = await _usuarioApplication.AutenticarAsync(requestDto);
        return Ok(result);
    }

    [HttpPost("revalidar-token")]
    public async Task<IActionResult> RevalidarTokenAsync([FromBody] UsuarioRevalidarTokenRequestDto requestDto)
    {
        var result = await _usuarioApplication.RevalidarTokenAsync(requestDto);
        return Ok(result);
    }
}
