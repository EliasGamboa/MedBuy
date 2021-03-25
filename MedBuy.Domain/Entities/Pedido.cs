using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public ICollection<Producto> Productos { get; set; }
    }
}
