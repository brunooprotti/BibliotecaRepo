using Biblioteca.Domain.Libros;
using Biblioteca.Domain.Libros.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Configurations;

internal sealed class LibroConfiguration : IEntityTypeConfiguration<Libro>
{
    public void Configure(EntityTypeBuilder<Libro> builder)
    {
        builder.ToTable("Libros");

        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id)
            .ValueGeneratedOnAdd();
    
        builder.Property(l => l.Titulo)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(l => l.PublicationYear)
               .HasMaxLength(4)
               .IsRequired();

        builder.Property(l => l.Disponible)
                .IsRequired();


        builder.Property(l => l.Genero)
            .HasConversion(g => g!.Value, value => new Genero(value));

        builder.Property(l => l.Genero)
               .HasMaxLength(50)
               .IsRequired();

        builder.HasOne(l => l.Autor)
            .WithMany(a => a.Libros)
            .HasForeignKey(l => l.AutorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
