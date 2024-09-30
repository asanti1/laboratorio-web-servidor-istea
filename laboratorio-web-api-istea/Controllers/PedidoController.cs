using laboratorio_web_api_istea.DAL.Entities;
using laboratorio_web_api_istea.DAL.Enum;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Pedido;
using laboratorio_web_api_istea.Service;
using laboratorio_web_api_istea.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace laboratorio_web_api_istea.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoService;

    public PedidoController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [Authorize(Roles = RolesUsuarioConst.Socio)]
    [HttpGet("GetPedidos")]
    public async Task<ActionResult<List<PedidoResponseDTO>>> GetPedidos()
    {
        var pedidos = await _pedidoService.GetPedidos();
        if (pedidos == null) return Ok(new List<PedidoResponseDTO>());
        return Ok(pedidos);

    }

    [Authorize(Roles = RolesUsuarioConst.Cocinero + "," + RolesUsuarioConst.Cervecero + "," + RolesUsuarioConst.Bartender)]
    [HttpGet("GetPedidosPendientes")]
    public async Task<ActionResult<List<PedidoResponseDTO>>> GetPedidosPendientes()
    {
        var userRol = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        var pedidos = await _pedidoService.GetPedidosPorRol(userRol);
        if (pedidos == null) return NotFound();
        var pedidosPendientes = pedidos?.Where(p => p.EstadosPedido != "Listo para servir").ToList();
        return Ok(pedidosPendientes);
    }

    [Authorize(Roles = RolesUsuarioConst.Mozo)]
    [HttpGet("GetPedidosListos")]
    public async Task<ActionResult<List<PedidoResponseDTO>>> GetPedidosListos()
    {
        var pedidos = await _pedidoService.GetPedidosListos();
        if (pedidos == null) return NotFound();
        return Ok(pedidos);
    }

    [Authorize(Roles = RolesUsuarioConst.Socio)]
    [HttpGet("GetPedidos/{sector}")]
    public async Task<ActionResult<List<PedidoResponseDTO>>> GetPedidosPorSector(string sector)
    {
        var pedidos = await _pedidoService.GetPedidosPorSector(sector);
        if (pedidos == null) return NotFound();
        return Ok(pedidos);
    }

    [HttpGet("GetPedidosRetrasados")]
    public async Task<ActionResult<List<PedidoResponseDTO>>> GetPedidosNoEntregadosATiempo()
    {
        var pedidos = await _pedidoService.GetPedidosNoEntregadosATiempo();
        if (pedidos == null) return NotFound();
        return Ok(pedidos);
    }

    [HttpGet("GetPedidoPorId/{id}")]
    public async Task<ActionResult<PedidoResponseDTO>> GetPedidoPorId(int id)
    {
        var pedido = await _pedidoService.GetPedidoPorId(id);
        if (pedido == null) return NotFound();
        return Ok(pedido);
    }

    [Authorize(Roles = RolesUsuarioConst.Cocinero + "," + RolesUsuarioConst.Cervecero + "," + RolesUsuarioConst.Bartender)]
    [HttpPut("CambiarEstadoPedidoEnPreparacion/{pedidoId}")]
    public async Task<ActionResult<PedidoResponseDTO>> CambiarEstadoPedidoEnPreparacion([FromRoute] int pedidoId)
    {
        try
        {
            var userRol = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;


            var sectorDescription = _pedidoService.ObtenerSectorPorRol(userRol);

            var pedido = await _pedidoService.CambiarEstadoPedido(pedidoId, sectorDescription, (int) EstadoPedidoEnum.EN_PREPARACION);
            if (pedido == null) return NotFound("Pedido no encontrado.");

            return Ok(pedido);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
        }
    }

    [Authorize(Roles = RolesUsuarioConst.Cocinero + "," + RolesUsuarioConst.Cervecero + "," + RolesUsuarioConst.Bartender)]
    [HttpPut("CambiarEstadoPedidoListoParaServir/{pedidoId}")]
    public async Task<ActionResult<PedidoResponseDTO>> CambiarEstadoPedidoListoParaServir([FromRoute] int pedidoId)
    {
        try
        {
            var userRol = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var sectorDescription = _pedidoService.ObtenerSectorPorRol(userRol);

            var pedido = await _pedidoService.CambiarEstadoPedido(pedidoId, sectorDescription, (int)EstadoPedidoEnum.LISTO_PARA_SERVIR);
            if (pedido == null) return NotFound("Pedido no encontrado.");

            return Ok(pedido);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
        }
    }

    [Authorize(Roles = RolesUsuarioConst.Mozo)]
    [HttpPost("AddPedido")]
    public async Task<ActionResult> AddPedido([FromBody] PedidoPostDTO pedido)
    {
        var ped = await _pedidoService.AddPedido(pedido);
        return Created(string.Empty, string.Empty);
    }

    [HttpGet("GetMenosPedido")]
    public async Task<ActionResult<PedidoResponseDTO>> GetMenosPedido()
    {
        var pedidos = await _pedidoService.GetMenosPedido();
        return Ok(pedidos);
    }

    [HttpGet("GetMasPedido")]
    public async Task<ActionResult<PedidoResponseDTO>> GetMasPedido()
    {
        var pedidos = await _pedidoService.GetMasPedido();
        return Ok(pedidos);
    }
}