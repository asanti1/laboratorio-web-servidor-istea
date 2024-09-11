using System;
using System.Collections.Generic;

namespace laboratorio_web_api_istea.DAL.Models;

public class Sectore : ClaseBase
{
    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; }
    public virtual ICollection<Producto> Productos { get; set; }
}