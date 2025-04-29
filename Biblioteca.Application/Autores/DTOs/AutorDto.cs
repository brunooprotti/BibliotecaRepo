using Biblioteca.Application.Libros.DTOs;

namespace Biblioteca.Application.Autores.DTOs;

public class AutorDto 
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string? Nacionalidad { get; set; }
    public List<LibroDto> Libros { get; set; } = new();
}
