using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reto.API.Model;
using Reto.Application.Core.Cliente.Commands;
using Reto.Application.Core.Cliente.Queries;

namespace Reto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetClientesQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteModel body)
        {
            var command = body.Adapt<CreateClienteCommand>();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteModel body)
        {
            var command = body.Adapt<UpdateClienteCommand>();
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteClienteCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
