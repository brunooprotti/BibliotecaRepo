using Biblioteca.Domain.Abstractions;
using System.Net;

namespace Biblioteca.Domain.Autores.Errors;

public static class AutorErrorBuilder
{
    public static Error AutorNotFound(int id) => Error.Create($"No se pudo encontrar el Autor con el id {id}",HttpStatusCode.NotFound,"Autor.NotFound");
    public static Error AutorDuplicated(string nombre, string apellido) => Error.Create($"El autor {nombre} {apellido} ya se encuentra en nuestra base de datos.", HttpStatusCode.NotFound, "Autor.NotFound");
    public static Error AutorNotCreated(string nombre, string apellido) => Error.Create($"El autor {nombre} {apellido} no se pudo crear.", HttpStatusCode.Conflict, "Autor.CannotCreate");
}
