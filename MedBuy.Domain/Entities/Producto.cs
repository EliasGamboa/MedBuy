using System;
using System.Collections.Generic;

#nullable disable

namespace MedBuy.Domain.Entities
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sector { get; set; }
        public int? CantDisponible { get; set; }
        public double Costo { get; set; }
        public bool Activo { get; set; }
    }
}
