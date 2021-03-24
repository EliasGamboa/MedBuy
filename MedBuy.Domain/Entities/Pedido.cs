using System;
using System.Collections.Generic;

#nullable disable

namespace MedBuy.Domain.Entities
{
    public partial class Pedido
    {
        public double CostTotal { get; set; }
        public DateTime Fechrealizacion { get; set; }
        public int PedidoId { get; set; }
        public int Cantidad { get; set; }
    }
}
