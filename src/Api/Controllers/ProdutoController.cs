using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagueiBaratoApi.Application.Interfaces;

namespace PagueiBaratoApi.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoApplication _produtoApplication;

    public ProdutoController(IProdutoApplication produtoApplication)
    {
        _produtoApplication = produtoApplication;
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> ObterPorIdAsync(int id)
    {
        var result = await _produtoApplication.ObterPorIdAsync(id);
        return Ok(result);
    }
}