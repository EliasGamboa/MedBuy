using System;
using System.Collections.Generic;

#nullable disable

namespace MedBuy.Domain.Entities
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoProductos = new HashSet<PedidoProducto>();
        }

        public DateTime Fechrealizacion { get; set; }
        public int PedidoId { get; set; }

        public virtual ICollection<PedidoProducto> PedidoProductos { get; set; }
    }
}
