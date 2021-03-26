using MedBuy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedBuy.Domain.DTOs
{
    [Serializable]
    public class PedidoResponseDto
    {
        public int PedidoId { get; set; }
        public DateTime Fechrealizacion { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double CostTotal { get; set; }

        public virtual ProductoResponseDto Producto { get; set; }
    }
}
