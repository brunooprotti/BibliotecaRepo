using Biblioteca.Domain.Entities.ValueObjects;

namespace Biblioteca.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string? Nombre { get; private set; }
    public string? Apellido { get; private set; }
    public string? Email { get; private set; }
    public string? Telefono { get; private set; }
    public Direccion? Direccion { get; private set; }
    public List<Prestamo> Prestamos { get; private set; } = null!;

    private Usuario() { }
    private Usuario(string nombre, string apellido, string email, string telefono, Direccion direccion)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Telefono = telefono;
        Direccion = direccion;
    }

    public static Usuario Crear(string nombre, string apellido, string email, string telefono, Direccion direccion)
        => new Usuario(nombre, apellido, email, telefono, direccion);
}
