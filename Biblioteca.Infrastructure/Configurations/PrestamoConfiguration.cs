using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Configurations;

internal sealed class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo>
{
    public void Configure(EntityTypeBuilder<Prestamo> builder)
    {
        builder.ToTable("Prestamos");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.FechaPrestamo)
            .HasColumnType("datetime")
            .IsRequired();
        
        builder.Property(p => p.FechaDevolucion)
            .HasColumnType("datetime");

        builder.HasOne(p => p.Usuario)
               .WithMany(u => u.Prestamos)
               .HasForeignKey(u => u.UsuarioId)
               .IsRequired();
    }
}
