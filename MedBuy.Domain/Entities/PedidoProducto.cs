﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MedBuy.Domain.Entities
{
    public partial class PedidoProducto
    {
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double CostTotal { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
    }
}