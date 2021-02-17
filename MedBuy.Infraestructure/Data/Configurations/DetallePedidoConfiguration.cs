using MedBuy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedBuy.Infraestructure.Data.Configurations
{
    public class DetallePedidoConfiguration : IEntityTypeConfiguration<DetallePedido>
    {
        public void Configure(EntityTypeBuilder<DetallePedido> builder)
        {
            builder.HasNoKey();

            builder.ToTable("DetallePedido");

            builder.Property(e => e.PedidoId).HasColumnName("PedidoID");

            builder.Property(e => e.ProductoId).HasColumnName("ProductoID");

            builder.HasOne(d => d.Pedido)
                .WithMany()
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK_ProductoPedido_Pedido");

            builder.HasOne(d => d.Producto)
                .WithMany()
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_ProductoPedido_Producto");
        }
    }
}
