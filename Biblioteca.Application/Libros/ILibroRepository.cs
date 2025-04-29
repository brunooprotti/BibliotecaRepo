using Biblioteca.Domain.Abstractions;
using Biblioteca.Domain.Libros;

namespace Biblioteca.Application.Libros;

public interface ILibroRepository
{
    Task<Result<Libro,Error?>> GetLibroById(int id);
    Task<Result<ICollection<Libro>,Error?>> GetAllLibros();
    Task<Result<bool,Error?>> Create(Libro libro);
    Task<Result<bool,Error?>> Update(Libro libro);
    Task<Result<bool,Error?>> Delete(int id);
}
