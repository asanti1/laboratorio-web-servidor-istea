using System.ComponentModel.DataAnnotations.Schema;

namespace laboratorio_web_api_istea.DAL.Models
{
    public class RegistroEmpleados : ClaseBase
    {
        public int Id { get; set; } = 0;

        [ForeignKey(nameof(Empleado))] public int IdEmpleado { get; set; }

        public virtual Empleado Empleado { get; set; } = null!;

        public DateTime FechaHora { get; set; }
    }
}
