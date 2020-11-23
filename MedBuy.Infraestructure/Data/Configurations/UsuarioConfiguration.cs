using MedBuy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedBuy.Infraestructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.Property(e => e.Contraseña)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.Property(e => e.Usuario1)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
