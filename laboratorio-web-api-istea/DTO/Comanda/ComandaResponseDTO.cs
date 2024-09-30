using laboratorio_web_api_istea.DTO.Pedido;

namespace laboratorio_web_api_istea.DTO.Comanda
{
    public class ComandaResponseDTO
    {
        public string NombreCliente { get; set; }
        public string NombreMesa { get; set; }
        public List<PedidoResponseDTO> Pedidos { get; set; }
    }
}
