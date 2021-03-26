using System;
using System.Collections.Generic;

#nullable disable

namespace MedBuy.Domain.Entities
{
    public partial class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime Fechrealizacion { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double CostTotal { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
