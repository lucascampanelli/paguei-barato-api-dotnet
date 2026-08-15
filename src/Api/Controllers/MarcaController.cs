using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Marca;

namespace PagueiBaratoApi.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MarcaController : ControllerBase
{
    private readonly IMarcaApplication _marcaApplication;

    public MarcaController(IMarcaApplication marcaApplication)
    {
        _marcaApplication = marcaApplication;
    }

    [HttpPost]
    public async Task<IActionResult> CriarAsync([FromBody] MarcaCriarRequestDto requestDto)
    {
        var jwtSubject = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (jwtSubject == null || !Guid.TryParse(jwtSubject, out Guid criadoPorId))
            return Unauthorized();

        var result = await _marcaApplication.CriarAsync(requestDto, criadoPorId);
        return CreatedAtAction(nameof(CriarAsync), result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> ObterPorIdAsync(int id)
    {
        var result = await _marcaApplication.ObterPorIdAsync(id);
        return Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> ListarAsync([FromQuery] MarcaListarRequestDto? requestDto = null)
    {
        var result = await _marcaApplication.ListarAsync(requestDto);
        return Ok(result);
    }
}
