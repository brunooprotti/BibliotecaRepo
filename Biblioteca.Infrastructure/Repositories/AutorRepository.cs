using Biblioteca.Application.Repositories;
using Biblioteca.Domain.Abstractions;
using Biblioteca.Domain.Autores;
using Biblioteca.Domain.Autores.Errors;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories;

public sealed class AutorRepository : IAutorRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Autor> _dbSet;
    public AutorRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<Autor>();
    }

    public async Task<Result<bool,Error?>> Create(Autor autor, CancellationToken cancellationToken)
    {
        var autorExists = await _dbSet.AnyAsync(x => x.Apellido == autor.Apellido &&
                                                     x.Nombre == autor.Nombre && 
                                                     x.FechaNacimiento == autor.FechaNacimiento);

        if (autorExists)
            return Result<bool, Error?>.Failure(AutorErrorBuilder.AutorDuplicated(autor.Nombre!, autor.Apellido!));
    
        return Result<bool, Error?>.Success(true);
    }

    public Task<Result<bool, Error?>> Delete(int autorId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result<ICollection<Autor>, Error?>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool, Error?>> Update(Autor autor, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
