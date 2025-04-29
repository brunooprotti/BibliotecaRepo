using Biblioteca.Domain.Abstractions;
using System.Net;

namespace Biblioteca.Domain.Libros.Errors;

public static class LibroErrorBuilder
{
    public static Error LibroDuplicated(string tituloLibro) => Error.Create($"El libro {tituloLibro} ya esta registrado en nuestra BDD", HttpStatusCode.Conflict, "Libro.Create.Duplicated");

    public static Error? LibroNotCreated(string tituloLibro) =>  Error.Create($"El libro {tituloLibro} no se pudo registrar.", HttpStatusCode.Conflict, "Libro.Create.CannotCreate");
}
