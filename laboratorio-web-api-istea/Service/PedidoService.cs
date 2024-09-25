using AutoMapper;
using laboratorio_web_api_istea.DAL;
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
        return await _unitOfWork.PedidoRepository.GetId(id);
    }

    public async Task<PedidoResponseDTO> CambiarEstadoPedido(int id, int estado)
    {
        // Llama al repositorio para cambiar el estado del pedido
        var pedidoResponseDTO = await _unitOfWork.PedidoRepository.CambiarEstadoPedido(id, estado);

        // Devuelve el DTO
        return pedidoResponseDTO;
    }


    public async Task<Pedido> AddPedido(PedidoPostDTO pedidoDTO)
    {
        Pedido pedido = _mapper.Map<Pedido>(pedidoDTO);
        return await _unitOfWork.PedidoRepository.AddPedido(pedido);
    }
}