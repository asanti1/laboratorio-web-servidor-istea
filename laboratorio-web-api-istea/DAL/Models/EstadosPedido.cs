using System;
using System.Collections.Generic;

namespace laboratorio_web_api_istea.DAL.Models;

public class EstadosPedido : ClaseBase
{
    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}