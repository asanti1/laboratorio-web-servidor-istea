namespace laboratorio_web_api_istea.DAL.Models
{
    public class OperacionesPorSectorPorEmpleado
    {
        public string NombreEmpleado { get; set; } = null!;
        public int CantidadPedidos { get; set; } = 0; 
    }
    public class OperacionesPorSectorYEmpleado
    {
        public string SectorDescripcion { get; set; } = null!;
        public string NombreEmpleado { get; set; } = null!;
        public int CantidadPedidos { get; set; } = 0;
    }
}
