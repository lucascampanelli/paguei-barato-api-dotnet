using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagueiBaratoApi.Domain.Applications;
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
    public async Task<IActionResult> CriarUsuario([FromBody] UsuarioCriarRequestDto requestDto)
    {
        var result = await _usuarioApplication.CriarAsync(requestDto);
        return CreatedAtAction(nameof(CriarUsuario), result);
    }
}
