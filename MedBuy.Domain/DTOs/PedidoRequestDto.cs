using MedBuy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedBuy.Domain.DTOs
{
    public class PedidoRequestDto
    {
        public double CostTotal { get; set; }
        public DateTime Fechrealizacion { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
