using System;
using System.Collections.Generic;

namespace laboratorio_web_api_istea.DAL.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int IdComanda { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public int IdEstado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaFinalizacion { get; set; }

    public virtual Comanda IdComandaNavigation { get; set; } = null!;

    public virtual EstadosPedido IdEstadoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
