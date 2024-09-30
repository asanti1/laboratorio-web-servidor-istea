using laboratorio_web_api_istea.DTO.Sector;
using laboratorio_web_api_istea.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace laboratorio_web_api_istea.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SectorController : ControllerBase
{
    private readonly ISectorService _sectorService;

    public SectorController(ISectorService sectorService)
    {
        _sectorService = sectorService;
    }

    [HttpGet("GetOperacionesPorSector/{sectorDescripcion}")]
    public async Task<ActionResult<OperacionesPorSectorDTO>> GetOperacionesPorSector(string sectorDescripcion)
    {
        try
        {
            // Llama al servicio para obtener las operaciones por sector, pasando la descripción del sector
            var result = await _sectorService.GetOperacionesPorSector(sectorDescripcion);

            if (result == null)
            {
                return NotFound($"No se encontraron operaciones para el sector: {sectorDescripcion}");
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }


    [HttpGet("GetOperacionesPorSectorPorEmpleado/{sectorDescripcion}")]
    public async Task<ActionResult<OperacionesPorSectorPorEmpleadoDTO>> GetOperacionesPorSectorPorEmpleado(string sectorDescripcion)
    {
        try
        {
            // Llama al servicio para obtener las operaciones por sector por empleado
            var result = await _sectorService.GetOperacionesPorSectorPorEmpleado(sectorDescripcion);

            if (result == null)
            {
                return NotFound($"No se encontraron empleados para el sector: {sectorDescripcion}");
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }

}