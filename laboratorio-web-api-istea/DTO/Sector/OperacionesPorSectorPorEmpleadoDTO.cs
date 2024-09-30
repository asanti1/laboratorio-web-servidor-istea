
namespace laboratorio_web_api_istea.DTO.Sector;

public class OperacionesPorSectorPorEmpleadoDTO
{
    public string NombreEmpleado { get; set; } = null!;
    public int CantidadPedidos { get; set; } = 0;
}

public class OperacionesPorSectorYEmpleadoDTO
{
    public string SectorDescripcion { get; set; } = null!;
    public string NombreEmpleado { get; set; } = null!;
    public int CantidadPedidos { get; set; } = 0;
}