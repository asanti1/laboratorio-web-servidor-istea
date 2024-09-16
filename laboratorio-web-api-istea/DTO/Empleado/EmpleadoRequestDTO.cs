using laboratorio_web_api_istea.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace laboratorio_web_api_istea.DTO.Empleado
{
    public class EmpleadoRequestDTO
    {
        public string Nombre { get; set; }

        public string Usuario { get; set; }

        public  string Password { get; set; }
        public int IdSector { get; set; }

        public int RoleId { get; set; }
    }
}