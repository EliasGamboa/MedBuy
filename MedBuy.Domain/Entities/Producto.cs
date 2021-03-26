using System;
using System.Collections.Generic;

#nullable disable

namespace MedBuy.Domain.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int ProductoId { get; set; }
        public bool Activo { get; set; }
        public int? Cantdisponible { get; set; }
        public double? Costo { get; set; }
        public string Nombre { get; set; }
        public string Sector { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
