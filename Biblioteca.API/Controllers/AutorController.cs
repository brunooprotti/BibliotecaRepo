using Biblioteca.Application.Autores.Command;
using Biblioteca.Application.Autores.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAutorCommand command)
        {
            var result = await _mediator.Send(command);
            
            if (!result.IsSuccess)
                return BadRequest(result.Error);
            
            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllAutoresQuery());

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }
    }
}
