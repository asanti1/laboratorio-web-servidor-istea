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
    public async Task<ActionResult> CerrarMesa(string nombreMesa)
    {
        try
        {
            await _mesaService.CerrarMesa(nombreMesa);
            return Ok($"La mesa {nombreMesa} se cerró correctamente");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }


    [Authorize(Roles = RolesUsuarioConst.Socio + "," + RolesUsuarioConst.Mozo)]
    [HttpPut("AbrirMesa")]
    public async Task <ActionResult> AbrirMesa(string nombreMesa)
    {

        try
        {
            await _mesaService.CambiarEstado(nombreMesa, (int)EstadoMesaEnum.ClienteEsperando);
            return Ok($"La mesa {nombreMesa} se abrio correctamente");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    
     
    }

    [Authorize(Roles = RolesUsuarioConst.Mozo)]
    [HttpPut("CambiarEstadoClienteComiendo")]
    public async Task<ActionResult> CambiarEstadoClienteComiendo(string nombreMesa)
    {

        try
        {
            await _mesaService.CambiarEstado(nombreMesa, (int)EstadoMesaEnum.ClienteEsperando);
            return Ok($"La mesa {nombreMesa} cambio su estado");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }

    [Authorize(Roles = RolesUsuarioConst.Mozo)]
    [HttpPut("CambiarEstadoClientePagando")]
    public async Task<ActionResult> CambiarEstadoClientePagando(string nombreMesa)

    {
        try
        {
            await _mesaService.CambiarEstado(nombreMesa, (int)EstadoMesaEnum.ClienteEsperando);
            return Ok($"La mesa {nombreMesa} cambio su estado");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
}