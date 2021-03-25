using System;
using System.Collections.Generic;
using System.Text;

namespace MedBuy.Domain.DTOs
{
    public class PedidoProductoRequestDto
    {
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double CostTotal { get; set; }

        public virtual PedidoRequestDto Pedido { get; set; }
        public virtual ProductoRequestDto Producto { get; set; }
    }
}
