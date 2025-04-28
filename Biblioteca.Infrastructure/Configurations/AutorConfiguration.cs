using Biblioteca.Domain.Autores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Configurations;

internal sealed class AutorConfiguration : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> builder)
    {
        builder.ToTable("Autores");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder.Property(a => a.Nombre)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Apellido)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Nacionalidad)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.FechaNacimiento)
            .HasColumnType("datetime")
            .IsRequired();
    }
}
