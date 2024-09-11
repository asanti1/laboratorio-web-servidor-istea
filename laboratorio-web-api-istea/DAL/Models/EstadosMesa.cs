using System;
using System.Collections.Generic;

namespace laboratorio_web_api_istea.DAL.Models;

public class EstadosMesa : ClaseBase
{
    public string Descripcion { get; set; }

    public virtual ICollection<Mesa> Mesas { get; set; } = new List<Mesa>();
}