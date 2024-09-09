namespace laboratorio_web_api_istea.DTO.Comanda;

public class PedidoEnComandaGetDTO
{
    public string NombreProducto { get; set; }
    public string Precio { get; set; }
    public string Sector { get; set; }
}


public class ComandaGetDTO
{
    public string NombreCliente { get; set; }
    public string NombreMesa { get; set; }
    public List<PedidoEnComandaGetDTO> Productos { get; set; }
}