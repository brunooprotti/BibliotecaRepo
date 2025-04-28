using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Prestamos;

public class Prestamo
{
    public int Id { get; set; }
    public DateTime FechaPrestamo { get; private set; }
    public DateTime FechaDevolucion { get; private set; }
    public int UsuarioId { get; private set; }
    public Usuario? Usuario { get; private set; }
    public List<LibroPrestamo> Libros { get; private set; } = null!;

    private Prestamo() { }

    private Prestamo(DateTime fechaPrestamo, DateTime fechaDevolucion, int usuarioId)
    {
        FechaPrestamo = fechaPrestamo;
        FechaDevolucion = fechaDevolucion;
        UsuarioId = usuarioId;
    }

    public static Prestamo Crear(DateTime fechaPrestamo, DateTime fechaDevolucion, int usuarioId)
        => new Prestamo(fechaPrestamo, fechaDevolucion, usuarioId);
}
