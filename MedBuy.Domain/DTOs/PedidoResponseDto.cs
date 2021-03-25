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
        public PedidoResponseDto()
        {
            PedidoProductos = new HashSet<PedidoProductoResponseDto>();
        }

        public DateTime Fechrealizacion { get; set; }
        public int PedidoId { get; set; }

        public virtual ICollection<PedidoProductoResponseDto> PedidoProductos { get; set; }
        [NotMapped]
        public ICollection<Producto> Productos { get; set; }
    }
}
