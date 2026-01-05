using Microsoft.AspNetCore.Mvc;
using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Usuario;

namespace PagueiBaratoApi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
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
}
