using System;
using System.Collections.Generic;

namespace laboratorio_web_api_istea.DAL.Models;

public partial class Mesa
{
    public int IdMesa { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdEstado { get; set; }

    public virtual ICollection<Comanda> Comanda { get; set; } = new List<Comanda>();

    public virtual EstadosMesa IdEstadoNavigation { get; set; } = null!;
}