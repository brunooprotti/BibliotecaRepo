using Biblioteca.Application.Repositories;
using Biblioteca.Domain.Abstractions;
using Biblioteca.Domain.Autores;
using MediatR;

namespace Biblioteca.Application.Autores.Command;

public sealed class CreateAutorCommand : IRequest<Result<bool, Error?>>
{
    public string? Nombre { get; set; } 
    public string? Apellido { get; set; } 
    public DateTime FechaNacimiento { get; set; }
    public string? Nacionalidad { get; set; } 
}

internal sealed class CreateAutorCommandHandler : IRequestHandler<CreateAutorCommand, Result<bool, Error?>>
{
    private readonly IAutorRepository _repository;
    public CreateAutorCommandHandler(IAutorRepository repository)
    {
        _repository = repository;
    }


    public async Task<Result<bool,Error?>> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
    {
        var autor = Autor.Crear(request.Nombre!, request.Apellido!, request.FechaNacimiento, request.Nacionalidad!);
        var result = await _repository.Create(autor, cancellationToken);
        return result;
    }
}
