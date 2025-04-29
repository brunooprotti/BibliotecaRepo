using Biblioteca.Domain.Abstractions;
using Biblioteca.Domain.Libros;
using Biblioteca.Domain.Libros.ValueObjects;
using MediatR;

namespace Biblioteca.Application.Libros.Command;

public sealed record CreateLibroCommand : IRequest<Result<bool, Error?>>
{
    public string? Titulo { get; set; }
    public int AutorId { get; set; }
    public Genero? Genero { get; set; }
    public int PublicationYear { get; set; }
    public bool Disponible { get; } = true;
}

public sealed class CreateLibroCommandHandler : IRequestHandler<CreateLibroCommand, Result<bool, Error?>>
{
    private readonly ILibroRepository _libroRepository;
    public CreateLibroCommandHandler(ILibroRepository libroRepository)
    {
        _libroRepository = libroRepository;
    }

    public async Task<Result<bool, Error?>> Handle(CreateLibroCommand request, CancellationToken cancellationToken)
    {
        var libro = Libro.Crear(request.Titulo!, request.AutorId, request.Genero!, request.PublicationYear, request.Disponible);
        var result = await _libroRepository.Create(libro);
        return result;
    }
}
