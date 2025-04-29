using Biblioteca.Application.Libros.Command;
using Biblioteca.Application.Libros.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LibroController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateLibro([FromBody] CreateLibroCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
                return Ok(result.Value);
            
            return BadRequest(result.Error);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLibros()
        {
            var result = await _mediator.Send(new GetAllLibrosQuery());
            if (result.IsSuccess)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }
    }
}
