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
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
