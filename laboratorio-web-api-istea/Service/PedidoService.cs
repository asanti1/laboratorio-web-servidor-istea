using laboratorio_web_api_istea.DAL;
using laboratorio_web_api_istea.DAL.Enum;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace laboratorio_web_api_istea.Service;

public class PedidoService : IPedidoService
{
    private readonly IUnitOfWork _unitOfWork;
    public PedidoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<Pedido>> GetPedidos()
    {
        try
        {
            return await _unitOfWork.PedidoRepository.GetAll();
        }
        catch
        {
            throw new ApplicationException("An error occurred while retrieving employees.");
        }
    }

    public async Task<List<Pedido>> GetPedidosPorSector(string sector)
    {
        try {
            // Retrieve the sector by its description
            var newSector = await _unitOfWork.SectorRepository.GetSectorByDescription(sector);

        if (newSector == null)
        {
            // Handle the case where the sector is not found
            return new List<Pedido>(); // or throw an exception depending on your requirements
        }

            // Retrieve pedidos associated with the sector
            var pedidos = await _unitOfWork.PedidoRepository.GetPedidosBySector(newSector);

            return pedidos;
        }
        catch (Exception ex)
        {
            // Optionally log the exception
            // _logger.LogError(ex, "An error occurred while retrieving pedidos by sector.");

            throw new ApplicationException("An error occurred while retrieving pedidos by sector.", ex);
        }
    }
    
    public async Task<List<Pedido>> GetPedidosNoEntregadosATiempo()
    {
        try
        {
            return await _unitOfWork.PedidoRepository.GetPedidoByEstado((int)EstadoPedidoEnum.LISTO_PARA_SERVIR);
        }
        catch
        {
            throw new ApplicationException("An error occurred while retrieving orders.");
        }
    }

    public async Task<List<Pedido>> GetMenosPedido()
    {
        try
        {
            return await _unitOfWork.PedidoRepository.GetMenosPedido();
        }
        catch
        {
            throw new ApplicationException("An error occurred while retrieving the least ordered products.");
        }
    }

    public async Task<List<Pedido>> GetMasPedido()
    {
        try
        {
            return await _unitOfWork.PedidoRepository.GetMasPedido();
        }
        catch
        {
            throw new ApplicationException("An error occurred while retrieving the most ordered products.");
        }
    }

    public async Task<Pedido> GetPedidoPorId(int id)
    {
        try
        {
            if (id != null)
            {
                return await _unitOfWork.PedidoRepository.GetId(id);
            }
            throw new Exception("El id no puede ser nulo4"); 
        }
        catch
        {
            throw new ApplicationException("An error occurred while retrieving the order by ID.");
        }
    }

    public async Task<Pedido> CambiarEstadoPedido(int id, string estado)
    {
        try {

            Pedido pedido = await _unitOfWork.PedidoRepository.GetId(id);

            if (pedido == null)
            {
                throw new KeyNotFoundException("Order not found.");
            }

            pedido.IdEstado =Convert.ToInt16(estado);

            await _unitOfWork.PedidoRepository.Add(pedido);
            var result = await _unitOfWork.Save();

            return pedido;
        } 
        catch
        {
            throw new ApplicationException("An error occurred while changing the order status.");
        }
    }

    public async Task<Pedido> AddPedido(Pedido pedido)
    {
        try
        {
            await _unitOfWork.PedidoRepository.Add(pedido);
            var result = await _unitOfWork.Save();

            Pedido pedidoCreado = await _unitOfWork.PedidoRepository.GetId(pedido.IdPedido);
            return pedidoCreado;
        }
        catch
        {
            throw new ApplicationException("An error occurred while adding a new order.");
        }
    }
}