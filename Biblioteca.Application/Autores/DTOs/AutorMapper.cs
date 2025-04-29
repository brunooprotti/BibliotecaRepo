using AutoMapper;
using Biblioteca.Application.Libros.DTOs;
using Biblioteca.Domain.Autores;
using Biblioteca.Domain.Libros;

namespace Biblioteca.Application.Autores.DTOs;

internal class AutorMapper: Profile
{
    public AutorMapper()
    {
        CreateMap<Libro, LibroDto>();
        CreateMap<Autor, AutorDto>();
    }
}
