using MedBuy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedBuy.Domain.DTOs
{
    [Serializable]
    public class ProductoResponseDto
    {
        public ProductoResponseDto()
        {
            PedidoProductos = new HashSet<PedidoProducto>();
        }

        public bool Activo { get; set; }
        public int? Cantdisponible { get; set; }
        public double? Costo { get; set; }
        public string Nombre { get; set; }
        public string Sector { get; set; }
        public int ProductoId { get; set; }

        public virtual ICollection<PedidoProducto> PedidoProductos { get; set; }
    }
}
