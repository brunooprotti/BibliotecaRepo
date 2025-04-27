using Biblioteca.Domain.Entities.ValueObjects;

namespace Biblioteca.Domain.Entities;

public class Libro
{
    public int Id { get; private set; }
    public string? Titulo { get; private set; }
    public int AutorId { get; private set; }
    public Autor? Autor { get; private set; }
    public Genero? Genero { get; private set; }
    public int PublicationYear { get; private set; }
    public bool Disponible { get; private set; }

    private Libro() { }

    private Libro( string titulo, Autor autor, Genero genero, int publicationYear, bool disponible)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        PublicationYear = publicationYear;
        Disponible = disponible;
    }

    public Libro Crear(string titulo, Autor autor, Genero genero, int publicationYear, bool disponible)
        => new Libro(titulo, autor, genero, publicationYear, disponible);
    
}
