namespace laboratorio_web_api_istea.DTO.Empleado
{
    public class EmpleadoResponseDTO
    {
        public required int Id { get; set; }
        public required string Nombre { get; set; }

        public required string Usuario { get; set; }

        public required string Sector { get; set; }

        public required string Rol { get; set; }
    }
}
