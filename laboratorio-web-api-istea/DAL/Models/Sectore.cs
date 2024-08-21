using System;
using System.Collections.Generic;

namespace laboratorio_web_api_istea.DAL.Models;

public partial class Sectore
{
    public int IdSector { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
