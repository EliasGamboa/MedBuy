using System;
using System.Collections.Generic;
using System.Text;

namespace MedBuy.Domain.DTOs
{
    public class ProductoRequestDto
    {
        public string Nombre { get; set; }
        public string Sector { get; set; }
        public int? CantDisponible { get; set; }
        public double Costo { get; set; }
        public bool Activo { get; set; }
    }
}
