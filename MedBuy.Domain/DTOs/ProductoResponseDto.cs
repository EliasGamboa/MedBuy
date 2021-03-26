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
            Pedidos = new HashSet<PedidoResponseDto>();
        }

        public int ProductoId { get; set; }
        public bool Activo { get; set; }
        public int? Cantdisponible { get; set; }
        public double? Costo { get; set; }
        public string Nombre { get; set; }
        public string Sector { get; set; }

        public virtual ICollection<PedidoResponseDto> Pedidos { get; set; }
    }
}
