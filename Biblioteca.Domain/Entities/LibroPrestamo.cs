namespace Biblioteca.Domain.Entities;

public sealed class LibroPrestamo
{
    public int LibroId { get; private set; }
    public Libro? Libro { get; private set; }
    public int PrestamoId { get; private set; }
    public Prestamo? Prestamo { get; private set; }

    private LibroPrestamo() { }
    private LibroPrestamo(int libroId, int prestamoId)
    {
        LibroId = libroId;
        PrestamoId = prestamoId;
    }
    public static LibroPrestamo Crear(int libroId, int prestamoId)
        => new LibroPrestamo(libroId, prestamoId);
}
