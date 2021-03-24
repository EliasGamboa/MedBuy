using System;
using System.Collections.Generic;
using System.Text;

namespace MedBuy.Domain.DTOs
{
    [Serializable]
    public class ProductoResponseDto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Sector { get; set; }
        public int? CantDisponible { get; set; }
        public double Costo { get; set; }
        public bool Activo { get; set; }
    }
}
