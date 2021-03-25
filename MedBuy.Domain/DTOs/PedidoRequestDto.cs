using MedBuy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedBuy.Domain.DTOs
{
    [Serializable]
    public class PedidoRequestDto
    {
        public PedidoRequestDto()
        {
            PedidoProductos = new HashSet<PedidoProducto>();
        }

        public DateTime Fechrealizacion { get; set; }

        public virtual ICollection<PedidoProducto> PedidoProductos { get; set; }
    }
}
