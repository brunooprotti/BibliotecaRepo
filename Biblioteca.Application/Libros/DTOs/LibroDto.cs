using Biblioteca.Application.Autores.DTOs;
using Biblioteca.Domain.Libros.ValueObjects;

namespace Biblioteca.Application.Libros.DTOs;

public class LibroDto
{
    public string? Titulo { get; set; }
    public AutorDto? Autor { get; set; }
    public string? Genero { get; set; }
    public int PublicationYear { get; set; }
    public bool Disponible { get; set; }
}
