using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Comanda;
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
    public async Task<ActionResult<ComandaResponseDTO>> Get([FromRoute] int idComanda)
    {
        try
        {
            var comanda = await _comandaService.ObtenerComandaPorId(idComanda);

            return Ok(comanda);
        }
        catch (Exception ex)
        {
            return NotFound(new { Message = ex.Message });
        }
    }

    [HttpPost("Agregar")]
    public async Task<ActionResult<ComandaResponseDTO>> Add([FromBody] ComandaPostDTO comanda)
    {
        var comandaCreada = await _comandaService.Add(comanda);

        return Created(String.Empty, comandaCreada);
    }

    [HttpPut("ActualizarComanda/{idComanda}")]
    public async Task<ActionResult<ComandaResponseDTO>> Update([FromRoute] int idComanda, [FromBody] ComandaPostDTO comandaPostDto) // Cambiado a ComandaPostDTO
    {
        if (comandaPostDto == null)
        {
            return BadRequest("Comanda cannot be null."); // Retornar 400 si es nulo
        }

        try
        {
            // Llamar al servicio para actualizar la comanda
            var comandaActualizada = await _comandaService.Update(idComanda, comandaPostDto); // Cambiado a comandaPostDto

            if (comandaActualizada == null)
            {
                return NotFound(); // Retornar 404 si no se encuentra la comanda
            }

            return Ok(comandaActualizada); // Retornar la comanda actualizada en formato DTO
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error: " + ex.Message); // Manejo de errores
        }
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