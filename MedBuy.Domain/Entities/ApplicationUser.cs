using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedBuy.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
