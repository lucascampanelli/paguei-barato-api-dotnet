using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagueiBaratoApi.Application.Interfaces;
using PagueiBaratoApi.Domain.Dtos.Busca;

namespace PagueiBaratoApi.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BuscaController : ControllerBase
{
    private readonly IBuscaApplication _buscaApplication;

    public BuscaController(IBuscaApplication buscaApplication)
    {
        _buscaApplication = buscaApplication;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> BuscarAsync([FromQuery] BuscaCatalogoRequestDto requestDto)
    {
        var result = await _buscaApplication.BuscarAsync(requestDto);
        return Ok(result);
    }
}
