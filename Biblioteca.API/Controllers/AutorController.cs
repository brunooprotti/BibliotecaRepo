using Biblioteca.Application.Autores.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        private AutorController(IMediator mediator)
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

    }
}
