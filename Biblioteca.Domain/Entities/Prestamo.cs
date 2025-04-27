namespace Biblioteca.Domain.Entities;

public class Prestamo
{
    public int Id { get; set; }
    public DateTime FechaPrestamo { get; private set; }
    public DateTime FechaDevolucion { get; private set; }
    public int UsuarioId { get; private set; }
    public Usuario? Usuario { get; private set; }
    public List<Libro> Libro { get; private set; } = null!;
    public ICollection<LibroPrestamo> LibroPrestamos { get; private set; } = new List<LibroPrestamo>();
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
