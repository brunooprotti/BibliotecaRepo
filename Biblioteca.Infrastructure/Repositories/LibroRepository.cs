using Biblioteca.Application.Libros;
using Biblioteca.Domain.Abstractions;
using Biblioteca.Domain.Autores.Errors;
using Biblioteca.Domain.Autores;
using Biblioteca.Domain.Libros;
using Biblioteca.Domain.Libros.Errors;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Biblioteca.Infrastructure.Repositories;

internal sealed class LibroRepository : ILibroRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Libro> _dbSet;

    public LibroRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<Libro>();
    }

    public async Task<Result<bool, Error?>> Create(Libro libro)
    {
        var libroExists = await _dbSet.Include(l => l.Autor)
                                .AnyAsync(l => l.Titulo == libro.Titulo &&
                                               l.AutorId == libro.AutorId);

        if (libroExists)
            return Result<bool, Error?>.Failure(LibroErrorBuilder.LibroDuplicated(libro.Titulo!));

        await _dbSet.AddAsync(libro);
        var result = await _context.SaveChangesAsync();
        if (result == 0)
            return Result<bool, Error?>.Failure(LibroErrorBuilder.LibroNotCreated(libro.Titulo!));

        return Result<bool, Error?>.Success(true);
    }

    public Task<Result<bool, Error>> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<ICollection<Libro>, Error?>> GetAllLibros()
    {
        var result = await _dbSet.Include(l => l.Autor).ToListAsync();

        return Result<ICollection<Libro>, Error>.Success(result);
    }

    public Task<Result<Libro, Error>> GetLibroById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool, Error>> Update(Libro libro)
    {
        throw new NotImplementedException();
    }
}
