using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.Service;
using Microsoft.AspNetCore.Mvc;

namespace laboratorio_web_api_istea.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComandaController : ControllerBase
{
    private readonly ComandaService _comandaService;

    public ComandaController(ComandaService comandaService)
    {
        _comandaService = comandaService;
    }

    [HttpGet("Buscar/{idComanda}")]
    public Task<ActionResult<Comanda>> Get([FromRoute] int idComanda)
    {
        throw new NotImplementedException();
    }

    [HttpPost("Agregar")]
    public Task<ActionResult<Comanda>> Add([FromBody] Comanda comanda)
    {
        throw new NotImplementedException();
    }

    [HttpPut("ActualizarComanda/{idComanda}")]
    public Task<ActionResult<Comanda>> Update([FromRoute] int idComanda, [FromBody] Comanda comanda)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("BorrarComanda/{idComanda}")]
    public async Task<ActionResult> Delete([FromRoute] int idComanda)
    {
        var comanda = await _comandaService.Delete(idComanda);
        if (comanda != null)
        {
            return NoContent();
        }

        return NotFound();
    }
}