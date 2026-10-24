using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagueiBaratoApi.Application.Interfaces;

namespace PagueiBaratoApi.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class LojaController : ControllerBase
{
    private readonly ILojaApplication _lojaApplication;

    public LojaController(ILojaApplication lojaApplication)
    {
        _lojaApplication = lojaApplication;
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> ObterPorIdAsync(int id)
    {
        var result = await _lojaApplication.ObterPorIdAsync(id);
        return Ok(result);
    }
}
