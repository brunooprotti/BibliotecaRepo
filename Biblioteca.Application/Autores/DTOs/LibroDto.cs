namespace Biblioteca.Application.Autores.DTOs;

public class LibroDto
{
    public string? Titulo { get; set; }
    public string? Genero { get; set; }
    public int PublicationYear { get; set; }
    public bool Disponible { get; set; }
}
