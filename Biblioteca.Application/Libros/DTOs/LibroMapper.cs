using AutoMapper;
using Biblioteca.Domain.Autores;
using Biblioteca.Domain.Libros;

namespace Biblioteca.Application.Libros.DTOs;

internal class LibroMapper : Profile
{
    public LibroMapper()
    {
        CreateMap<Autor, AutorDto>();
        CreateMap<Libro, LibroDto>();
    } 
}
