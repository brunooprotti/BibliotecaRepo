using Biblioteca.Application.Autores;
using Biblioteca.Application.Libros;
using Biblioteca.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
            ?? throw new ArgumentNullException($"{nameof(DependencyInjection)}: Connection string doesn't exists");

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IAutorRepository,AutorRepository>();
        services.AddScoped<ILibroRepository,LibroRepository>();

        return services;
    }
}
