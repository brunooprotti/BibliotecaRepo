using Biblioteca.Domain.Libros;

namespace Biblioteca.Domain.Autores;

public sealed class Autor
{
    public int Id { get; set; }
    public string? Nombre { get; private set; }
    public string? Apellido { get; private set; }
    public DateTime FechaNacimiento { get; private set; }
    public string? Nacionalidad { get; private set; }
    public List<Libro> Libros { get; private set; } = new();
    private Autor()
    {

    }
    private Autor(string nombre, string apellido, DateTime fechaNacimiento, string nacionalidad)
    {
        Nombre = nombre;
        Apellido = apellido;
        FechaNacimiento = fechaNacimiento;
        Nacionalidad = nacionalidad;
    }
    public static Autor Crear(string nombre, string apellido, DateTime fechaNacimiento, string nacionalidad)
        => new Autor(nombre, apellido, fechaNacimiento, nacionalidad);
}
