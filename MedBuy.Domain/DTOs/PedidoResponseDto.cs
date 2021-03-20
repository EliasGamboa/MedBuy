using MedBuy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedBuy.Domain.DTOs
{
    [Serializable]
    public class PedidoResponseDto
    {
        public double CostTotal { get; set; }
        public DateTime Fechrealizacion { get; set; }
        public int PedidoId { get; set; }
        public int Cantidad { get; set; }
    }
}
