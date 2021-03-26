using System;
using MedBuy.Domain.Entities;
using MedBuy.Infraestructure.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
#nullable disable

namespace MedBuy.Infraestructure.Data
{
    public partial class MedBuyContext : IdentityDbContext<ApplicationUser>
    {
        public MedBuyContext()
        {
        }

        public MedBuyContext(DbContextOptions<MedBuyContext> options)
            : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Pedido>(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration<Producto>(new ProductoConfiguration());
        }

        
    }
}
