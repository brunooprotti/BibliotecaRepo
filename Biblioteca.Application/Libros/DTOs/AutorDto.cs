﻿namespace Biblioteca.Application.Libros.DTOs;

public class AutorDto 
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string? Nacionalidad { get; set; }
}
