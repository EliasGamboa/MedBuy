using MedBuy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedBuy.Infraestructure.Data.Configurations
{
    public class DetallePedidoConfiguration : IEntityTypeConfiguration<PedidoProducto>
    {
        public void Configure(EntityTypeBuilder<PedidoProducto> builder)
        {
            builder.HasKey(e => new { e.PedidoId, e.ProductoId });

            builder.ToTable("PedidoProducto");

            builder.Property(e => e.PedidoId).HasColumnName("PedidoID");

            builder.Property(e => e.ProductoId).HasColumnName("ProductoID");

            builder.HasOne(d => d.Pedido)
                .WithMany(p => p.PedidoProductos)
                .HasForeignKey(d => d.PedidoId);

            builder.HasOne(d => d.Producto)
                .WithMany(p => p.PedidoProductos)
                .HasForeignKey(d => d.ProductoId);
        }
    }
}
