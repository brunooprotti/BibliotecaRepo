using Biblioteca.Application.Autores;
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

        await _dbSet.AddAsync(autor);
        var result = await _context.SaveChangesAsync(cancellationToken) ;

        if (result == 0)
            return Result<bool, Error?>.Failure(AutorErrorBuilder.AutorNotCreated(autor.Nombre,autor.Apellido)); 

        return Result<bool, Error?>.Success(true);
    }

    public Task<Result<bool, Error?>> Delete(int autorId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<ICollection<Autor>, Error?>> Get()
    {
        var result = await _dbSet.Include(x => x.Libros).ToListAsync();
        return Result<ICollection<Autor>,Error>.Success(result);
    }

    public Task<Result<bool, Error?>> Update(Autor autor, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
