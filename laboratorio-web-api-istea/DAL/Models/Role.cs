using System;
using System.Collections.Generic;

namespace laboratorio_web_api_istea.DAL.Models;

public class Role : ClaseBase
{
    public string Descripcion { get; set; }
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}