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

    [HttpGet("GetOperacionesPorSector")]
    public async Task<ActionResult<OperacionesPorSectorDTO>> GetOperacionesPorSector()
    {
        return await _sectorService.GetOperacionesPorSector();
    }

    [HttpGet("GetOperacionesPorSectorPorEmpleado")]
    public async Task<ActionResult<OperacionesPorSectorPorEmpleadoDTO>> GetOperacionesPorSectorPorEmpleado()
    {
        return await _sectorService.GetOperacionesPorSectorPorEmpleado();
    }
}