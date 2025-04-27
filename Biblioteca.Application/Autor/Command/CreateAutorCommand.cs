using MediatR;

namespace Biblioteca.Application.Autor.Command;

public sealed class CreateAutorCommand : IRequest<Domain.Entities.Autor>
{
    public string? Nombre { get; set; } 
    public string? Apellido { get; set; } 
    public DateTime FechaNacimiento { get; set; }
    public string? Nacionalidad { get; set; } 
}

internal sealed class CreateAutorCommandHandler : IRequestHandler<CreateAutorCommand, Domain.Entities.Autor>
{
    private readonly IRepository<Domain.Entities.Autor> _repository;
    public CreateAutorCommandHandler(IRepository<Domain.Entities.Autor> repository)
    {
        _repository = repository;
    }
    public async Task<Domain.Entities.Autor> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
    {
        var autor = Domain.Entities.Autor.Crear(request.Nombre!, request.Apellido!, request.FechaNacimiento, request.Nacionalidad!);
        await _repository.AddAsync(autor, cancellationToken);
        return autor;
    }
}
