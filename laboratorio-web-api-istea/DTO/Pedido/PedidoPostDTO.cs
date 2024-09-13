namespace laboratorio_web_api_istea.DTO.Pedido;

public class PedidoPostDTO
{
    public int IdComanda { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public int IdEstado { get; set; }

    public DateTime? FechaFinalizacion { get; set; }
}