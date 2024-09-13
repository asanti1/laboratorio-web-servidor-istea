using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Comanda;
using laboratorio_web_api_istea.Service;
using laboratorio_web_api_istea.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace laboratorio_web_api_istea.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComandaController : ControllerBase
{
    private readonly IComandaService _comandaService;

    public ComandaController(IComandaService comandaService)
    {
        _comandaService = comandaService;
    }

    [HttpGet("Buscar/{idComanda}")]
    public async Task<ActionResult<ComandaGetDTO>> Get([FromRoute] int idComanda)
    {
        try
        {
            var comanda = await _comandaService.ObtenerComandaPorId(idComanda);
            return Ok(comanda);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
    }

    [HttpPost("Agregar")]
    public async Task<ActionResult<Comanda>> Add([FromBody] ComandaPostDTO comanda)
    {
        var comandaCreada = await _comandaService.Add(comanda); 
        return Created(String.Empty, comandaCreada);
    }

    [HttpPut("ActualizarComanda/{idComanda}")]
    public Task<ActionResult<Comanda>> Update([FromRoute] int idComanda, [FromBody] Comanda comanda)
    {
        throw new NotImplementedException();
    }

    //socio
    [HttpDelete("BorrarComanda/{idComanda}")]
    public async Task<ActionResult> Delete([FromRoute] int idComanda)
    {
        bool success = await _comandaService.Delete(idComanda);
        
        if (success)
        {
            return NoContent();
        }
        return NotFound();
    }
}