using laboratorio_web_api_istea.DAL.Entities;
using laboratorio_web_api_istea.DTO.Mesa;
using laboratorio_web_api_istea.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace laboratorio_web_api_istea.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MesaController : ControllerBase
{
    private readonly IMesaService _mesaService;

    public MesaController(IMesaService mesaService)
    {
        _mesaService = mesaService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<MesaResponseDTO>>> GetMesas()
    {
        var mesas = await _mesaService.GetMesas();
        return Ok(mesas);
    }

    [Authorize(Roles = RolesUsuarioConst.Socio)]
    [HttpPut("CerrarMesa")]
    public ActionResult CerrarMesa(string idMesa)
    {
        _mesaService.CerrarMesa(idMesa);
        return NoContent();
    }
}