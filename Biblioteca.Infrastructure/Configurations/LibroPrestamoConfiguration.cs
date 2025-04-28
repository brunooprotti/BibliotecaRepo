using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Configurations;

internal sealed class LibroPrestamoConfiguration : IEntityTypeConfiguration<LibroPrestamo>
{
    public void Configure(EntityTypeBuilder<LibroPrestamo> builder)
    {
        builder.ToTable("LibrosPrestamos");
        
        builder.HasKey(lp => new { lp.LibroId, lp.PrestamoId });

        builder.HasOne(lp => lp.Libro)
               .WithMany(l => l.Prestamos)
               .HasForeignKey(lp => lp.LibroId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(lp => lp.Prestamo)
               .WithMany(p => p.Libros)
               .HasForeignKey(lp => lp.PrestamoId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
