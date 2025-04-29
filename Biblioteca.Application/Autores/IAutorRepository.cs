using Biblioteca.Domain.Abstractions;
using Biblioteca.Domain.Autores;

namespace Biblioteca.Application.Autores;

public interface IAutorRepository
{
    Task<Result<ICollection<Autor>,Error?>> Get();
    Task<Result<bool,Error?>> Create(Autor autor, CancellationToken cancellationToken);
    Task<Result<bool, Error?>> Update(Autor autor, CancellationToken cancellationToken);
    Task<Result<bool, Error?>> Delete(int autorId, CancellationToken cancellationToken);
}
