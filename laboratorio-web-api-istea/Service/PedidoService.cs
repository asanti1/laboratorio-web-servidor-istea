using AutoMapper;
using laboratorio_web_api_istea.DAL;
using laboratorio_web_api_istea.DAL.Entities;
using laboratorio_web_api_istea.DAL.Enum;
using laboratorio_web_api_istea.DAL.Models;
using laboratorio_web_api_istea.DTO.Empleado;
using laboratorio_web_api_istea.DTO.Pedido;
using laboratorio_web_api_istea.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace laboratorio_web_api_istea.Service;

public class PedidoService : IPedidoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PedidoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<PedidoResponseDTO>> GetPedidos()
    {
        var pedidosEntity = await _unitOfWork.PedidoRepository.GetAllPedidos();
        List<PedidoResponseDTO> pedidosDTO = _mapper.Map<List<PedidoResponseDTO>>(pedidosEntity);
        return pedidosDTO;
    }

    public string ObtenerSectorPorRol(string userRole)
    {
        return userRole switch
        {
            RolesUsuarioConst.Bartender => "Barra de Tragos y Vinos",
            RolesUsuarioConst.Cervecero => "Barra de Choperas de Cerveza Artesanal",
            RolesUsuarioConst.Cocinero => "Cocina",
            RolesUsuarioConst.Mozo => "", 
        };
    }

    public async Task<List<PedidoResponseDTO>> GetPedidosListos() {
        var pedidosEntity = await _unitOfWork.PedidoRepository.GetPedidosListos();
        List<PedidoResponseDTO> pedidosDTO = _mapper.Map<List<PedidoResponseDTO>>(pedidosEntity);
        return pedidosDTO;
    }

    public async Task<List<PedidoResponseDTO>> GetPedidosPorSector(string sector)
    {
        try
        {
            var newSector = await _unitOfWork.SectorRepository.GetSectorByDescription(sector);

            if (newSector == null)
            {
                return new List<PedidoResponseDTO>();
            }

            var pedidos = await _unitOfWork.PedidoRepository.GetPedidosBySector(newSector);

            var pedidosDTO = _mapper.Map<List<PedidoResponseDTO>>(pedidos);

            return pedidosDTO;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while retrieving pedidos by sector.", ex);
        }
    }

    public async Task<List<PedidoResponseDTO>> GetPedidosPorRol(string rol)
    {
        try
        {
            var sector = ObtenerSectorPorRol(rol);

            var newSector = await _unitOfWork.SectorRepository.GetSectorByDescription(sector);

            if (newSector == null)
            {
                return new List<PedidoResponseDTO>();
            }

            var pedidos = await _unitOfWork.PedidoRepository.GetPedidosBySector(newSector);

            var pedidosDTO = _mapper.Map<List<PedidoResponseDTO>>(pedidos);

            return pedidosDTO;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while retrieving pedidos by sector.", ex);
        }
    }

    public async Task<List<PedidoResponseDTO>> GetPedidosNoEntregadosATiempo()
    {
        try
        {
            var pedidos = await _unitOfWork.PedidoRepository.GetPedidoByEstado((int)EstadoPedidoEnum.LISTO_PARA_SERVIR);
            var pedidosResponseDTO = _mapper.Map<List<PedidoResponseDTO>>(pedidos);

            return pedidosResponseDTO;
        }
        catch
        {
            throw new ApplicationException("An error occurred while retrieving orders.");
        }
    }


    public async Task<List<PedidoResponseDTO>> GetMenosPedido()
    {
        try
        {
            // Obtiene la lista de pedidos
            var pedidos = await _unitOfWork.PedidoRepository.GetMenosPedido();

            // Mapea la lista de pedidos a una lista de PedidoResponseDTO
            var pedidosResponseDTO = _mapper.Map<List<PedidoResponseDTO>>(pedidos);

            return pedidosResponseDTO;
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"An error occurred while retrieving the least ordered products: {ex.Message}");
        }
    }

    public async Task<List<PedidoResponseDTO>> GetMasPedido()
    {
        try
        {
            // Se obtiene la lista de pedidos más solicitados
            var pedidos = await _unitOfWork.PedidoRepository.GetMasPedido();

            // Mapeamos la lista de pedidos a PedidoResponseDTO
            var pedidosResponseDTO = _mapper.Map<List<PedidoResponseDTO>>(pedidos);

            return pedidosResponseDTO;
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"An error occurred while retrieving the most ordered products: {ex.Message}");
        }
    }

    public async Task<PedidoResponseDTO> GetPedidoPorId(int id)
    {
        try
        {
            // Obtenemos el pedido por ID
            var pedido = await _unitOfWork.PedidoRepository.GetId(id);

            // Verificamos si el pedido es nulo
            if (pedido == null)
            {
                throw new KeyNotFoundException("Order not found.");
            }

            // Mapeamos el pedido a PedidoResponseDTO
            var pedidoResponseDTO = _mapper.Map<PedidoResponseDTO>(pedido);

            return pedidoResponseDTO;
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"An error occurred while retrieving the order: {ex.Message}");
        }
    }


    public async Task<PedidoResponseDTO> CambiarEstadoPedido(int id, string sector, int estado)
    {
        // Llamamos al repositorio para cambiar el estado del pedido
        var pedido = await _unitOfWork.PedidoRepository.CambiarEstadoPedido(id, sector, estado);

        // Mapear el pedido actualizado a PedidoResponseDTO
        var pedidoDto = _mapper.Map<PedidoResponseDTO>(pedido);

        // Nos devuelve el DTO
        return pedidoDto;
    }


    public async Task<Pedido> AddPedido(PedidoPostDTO pedidoDTO)
    {
        Pedido pedido = _mapper.Map<Pedido>(pedidoDTO);
        return await _unitOfWork.PedidoRepository.AddPedido(pedido);
    }
}