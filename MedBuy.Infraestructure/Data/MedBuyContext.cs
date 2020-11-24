using System;
using MedBuy.Domain.Entities;
using MedBuy.Infraestructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
#nullable disable

namespace MedBuy.Infraestructure.Data
{
    public partial class MedBuyContext : DbContext
    {
        public MedBuyContext()
        {
        }

        public MedBuyContext(DbContextOptions<MedBuyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Producto>(new ProductoConfiguration());
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioConfiguration());
        }

        
    }
}
