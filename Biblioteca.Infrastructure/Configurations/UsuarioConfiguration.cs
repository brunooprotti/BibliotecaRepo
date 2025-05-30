﻿using Biblioteca.Domain.Autores.ValueObjects;
using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Configurations;

internal sealed class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(u => u.Id);
        builder.Property( u => u.Id)
               .ValueGeneratedOnAdd();

        builder.Property(u => u.Nombre)
               .HasMaxLength(100)
               .IsRequired();
        
        builder.Property(u => u.Apellido)
               .HasMaxLength(100)
               .IsRequired(); ;

        builder.Property(u => u.Telefono)
               .HasMaxLength(100);

        builder.Property(u => u.Direccion)
               .HasConversion(d => d!.Value, value => new Direccion(value))
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(u => u.Email)
               .HasMaxLength(50);
    }
}
