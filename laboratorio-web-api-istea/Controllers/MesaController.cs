using laboratorio_web_api_istea.DAL.Entities;
using laboratorio_web_api_istea.DAL.Enum;
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
    [Authorize(Roles = RolesUsuarioConst.Socio + "," + RolesUsuarioConst.Mozo)]
    [HttpGet("GetAll")]
    public async Task<ActionResult<List<MesaResponseDTO>>> GetMesas()
    {
        var mesas = await _mesaService.GetMesas();
        return Ok(mesas);
    }

    [Authorize(Roles = RolesUsuarioConst.Socio)]
    [HttpPut("CerrarMesa")]
    public ActionResult CerrarMesa(string nombreMesa)
    {
        _mesaService.CerrarMesa(nombreMesa);
        return NoContent();
    }

    [Authorize(Roles = RolesUsuarioConst.Socio + "," + RolesUsuarioConst.Mozo)]
    [HttpPut("AbrirMesa")]
    public ActionResult AbrirMesa(string nombreMesa)
    {
        _mesaService.CambiarEstado(nombreMesa, (int)EstadoMesaEnum.ClienteEsperando);
        return NoContent();
    }

    [Authorize(Roles = RolesUsuarioConst.Mozo)]
    [HttpPut("CambiarEstadoClienteComiendo")]
    public ActionResult CambiarEstadoClienteComiendo(string nombreMesa)
    {
        
        _mesaService.CambiarEstado(nombreMesa, (int) EstadoMesaEnum.ClienteComiendo);
        return NoContent();
    }

    [Authorize(Roles = RolesUsuarioConst.Mozo)]
    [HttpPut("CambiarEstadoClientePagando")]
    public ActionResult CambiarEstadoClientePagando(string nombreMesa)
    {
        _mesaService.CambiarEstado(nombreMesa, (int) EstadoMesaEnum.ClientePagando);
        return NoContent();
    }
}