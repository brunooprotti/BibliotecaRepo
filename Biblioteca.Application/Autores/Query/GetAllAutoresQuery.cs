using AutoMapper;
using Biblioteca.Application.Autores.DTOs;
using Biblioteca.Domain.Abstractions;
using MediatR;

namespace Biblioteca.Application.Autores.Query;

public sealed record GetAllAutoresQuery : IRequest<Result<ICollection<AutorDto>,Error?>> { }

public sealed class GetAllAutoresQueryHandler : IRequestHandler<GetAllAutoresQuery, Result<ICollection<AutorDto>, Error?>>
{
    private readonly IAutorRepository _repository;

    private readonly IMapper _mapper;
    public GetAllAutoresQueryHandler(IAutorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }   

    public async Task<Result<ICollection<AutorDto>, Error?>> Handle(GetAllAutoresQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.Get();
        var resultMapeado = _mapper.Map<ICollection<AutorDto>>(result.Value);

        return Result<ICollection<AutorDto>, Error?>.Success(resultMapeado);
    }
}
