using AutoMapper;
using Biblioteca.Application.Libros.DTOs;
using Biblioteca.Domain.Abstractions;
using MediatR;

namespace Biblioteca.Application.Libros.Query;

public class GetAllLibrosQuery : IRequest<Result<ICollection<LibroDto>,Error?>>;

public sealed class GetAllLibrosQueryHandler : IRequestHandler<GetAllLibrosQuery, Result<ICollection<LibroDto>, Error?>>
{
    private readonly ILibroRepository _libroRepository;
    private readonly IMapper _mapper;
    public GetAllLibrosQueryHandler(ILibroRepository libroRepository, IMapper mapper)
    {
        _libroRepository = libroRepository;
        _mapper = mapper;
    }
    public async Task<Result<ICollection<LibroDto>, Error?>> Handle(GetAllLibrosQuery request, CancellationToken cancellationToken)
    {
        var result = await _libroRepository.GetAllLibros();

        var resultMapeado = _mapper.Map<ICollection<LibroDto>>(result.Value);

        return Result<ICollection<LibroDto>, Error?>.Success(resultMapeado);
    }
}
