using laboratorio_web_api_istea.DAL.Models;

namespace laboratorio_web_api_istea.DTO.Pedido
{
    public class PedidoResponseDTO
    {
        public required int Cantidad { get; set; }
        public required DateTime FechaCreacion { get; set; }
        public required DateTime FechaFinalizacion { get; set; }
        public required string Producto { get; set; }
        public required string Mesa { get; set; }
        public required string NombreCliente { get; set; }
        public required string EstadosPedido { get; set; }
    } 
}
