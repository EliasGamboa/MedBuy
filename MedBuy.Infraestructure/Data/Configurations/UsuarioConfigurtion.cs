using MedBuy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedBuy.Infraestructure.Data.Configurations
{
    public class UsuarioConfigurtion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        { 
            
            builder.Property(e => e.Id);

            builder.Property(e => e.Apellido)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Contraseña)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("contraseña");

            builder.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Usuario1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Usuario");
        }

        
    }
}
