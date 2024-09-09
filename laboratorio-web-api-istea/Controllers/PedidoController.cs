using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Pedido;
using laboratorio_web_api_istea.Service;
using laboratorio_web_api_istea.Service.Interface;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("GetPedidos")]
    public async Task<ActionResult<List<Pedido>>> GetPedidos()
    {
        var pedidos = await _pedidoService.GetPedidos();
        if (pedidos == null) return NotFound();
        return Ok(pedidos);
    }

    [HttpGet("GetPedidos/{idSector}")]
    public async Task<ActionResult<List<Pedido>>> GetPedidosPorSector([FromRoute] string sector)
    {
        var pedidos = await _pedidoService.GetPedidosPorSector(sector);
        if (pedidos == null) return NotFound();
        return Ok(pedidos);
    }

    [HttpGet("GetPedidosRetrasados")]
    public async Task<ActionResult<List<Pedido>>> GetPedidosNoEntregadosATiempo()
    {
        var pedidos = await _pedidoService.GetPedidosNoEntregadosATiempo();
        if (pedidos == null) return NotFound();
        return Ok(pedidos);
    }

    [HttpGet("GetPedidoPorId/{id}")]
    public async Task<ActionResult<Pedido>> GetPedidoPorId([FromRoute] int id)
    {
        var pedido = await _pedidoService.GetPedidoPorId(id);
        if (pedido == null) return NotFound();
        return Ok(pedido);
    }

    [HttpPut("CambiarEstadoPedido/{pedidoId}")]
    public ActionResult<Pedido> CambiarEstadoPedido([FromRoute] int pedidoId, [FromBody] int estado)
    {
        var pedido = _pedidoService.CambiarEstadoPedido(pedidoId, estado);
        if (pedido == null) return NotFound();
        return Created(string.Empty, pedido);
    }

    [HttpPost("AddPedido")]
    public async Task<ActionResult> AddPedido([FromBody] PedidoPostDTO pedido)
    {
        var ped = await _pedidoService.AddPedido(pedido);
        return Created(string.Empty, string.Empty);
    }

    [HttpGet("GetMenosPedido")]
    public async Task<ActionResult<Pedido>> GetMenosPedido()
    {
        var pedidos = await _pedidoService.GetMenosPedido();
        return Ok(pedidos);
    }

    [HttpGet("GetMasPedido")]
    public async Task<ActionResult<Pedido>> GetMasPedido()
    {
        var pedidos = await _pedidoService.GetMasPedido();
        return Ok(pedidos);
    }
}