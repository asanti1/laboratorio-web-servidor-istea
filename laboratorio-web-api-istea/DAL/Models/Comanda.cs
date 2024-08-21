using System;
using System.Collections.Generic;

namespace laboratorio_web_api_istea.DAL.Models;

public partial class Comanda
{
    public int IdComanda { get; set; }

    public int IdMesa { get; set; }

    public string NombreCliente { get; set; } = null!;

    public virtual Mesa IdMesaNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
