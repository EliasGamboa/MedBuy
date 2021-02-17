using MedBuy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedBuy.Infraestructure.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.Property(e => e.PedidoId).HasColumnName("PedidoID");

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(450);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_Cliente");
        }
    }
}
