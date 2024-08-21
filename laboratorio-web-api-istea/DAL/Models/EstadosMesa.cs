using System;
using System.Collections.Generic;

namespace laboratorio_web_api_istea.DAL.Models;

public partial class EstadosMesa
{
    public int IdEstado { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Mesa> Mesas { get; set; } = new List<Mesa>();
}
