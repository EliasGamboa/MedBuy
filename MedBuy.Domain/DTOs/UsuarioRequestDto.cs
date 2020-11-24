using System;
using System.Collections.Generic;
using System.Text;

namespace MedBuy.Domain.DTOs
{
    public class UsuarioRequestDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Usuario1 { get; set; }
        public string Contraseña { get; set; }
    }
}
