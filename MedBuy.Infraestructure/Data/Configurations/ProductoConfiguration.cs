using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MedBuy.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedBuy.Infraestructure.Data.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Sector)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
