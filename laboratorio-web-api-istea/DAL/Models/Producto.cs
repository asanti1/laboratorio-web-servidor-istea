using System;
using System.Collections.Generic;

namespace laboratorio_web_api_istea.DAL.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int IdSector { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Stock { get; set; }

    public decimal Precio { get; set; }

    public virtual Sectore IdSectorNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
