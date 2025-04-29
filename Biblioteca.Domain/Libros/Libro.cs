using Biblioteca.Domain.Autores;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Libros.ValueObjects;

namespace Biblioteca.Domain.Libros;

public sealed class Libro
{
    public int Id { get; private set; }
    public string? Titulo { get; private set; }
    public int AutorId { get; private set; }
    public Autor? Autor { get; private set; }
    public Genero? Genero { get; private set; }
    public int PublicationYear { get; private set; }
    public bool Disponible { get; private set; }
    public List<LibroPrestamo>? Prestamos { get; private set; }

    private Libro() { }

    private Libro( string titulo, int autorId, Genero genero, int publicationYear, bool disponible)
    {
        Titulo = titulo;
        AutorId = autorId;
        Genero = genero;
        PublicationYear = publicationYear;
        Disponible = disponible;
    }

    public static Libro Crear(string titulo, int autorId, Genero genero, int publicationYear, bool disponible)
        => new Libro(titulo, autorId, genero, publicationYear, disponible);
    
}
