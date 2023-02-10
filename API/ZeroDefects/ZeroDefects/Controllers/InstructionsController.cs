using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZeroDefects.Commands.AddInstruction;
using ZeroDefects.Commands.DeleteInstruction;
using ZeroDefects.Domain.Entities;
using ZeroDefects.Domain.Interfaces;
using ZeroDefects.Infrastructure.Data.Repositories;
using ZeroDefects.Queries.GetInstructions;

namespace ZeroDefects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IInstructionsRepository _instructionsRepository;
        public InstructionsController(IMediator mediator, IInstructionsRepository instructionsRepository)
        {
            _mediator = mediator;
            _instructionsRepository = instructionsRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instructions>>> Get()
        {
            try
            {
                var items = await _mediator.Send(new GetInstructionsQuery());
                if (items != null)
                {
                    return Ok(items);
                }

                return NotFound();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Instructions>> Get(string id)
        {
            try
            {
                var item = await _mediator.Send(new GetInstructionByIdQuery() { InstructionId = id });
                if (item != null)
                {
                    return Ok(item);
                }

                return NotFound();
            }
            catch (Exception ex) 
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Instructions>> Post([FromBody] CreateInstructionCommand command)
        {
            var item = await _mediator.Send(command);
            if (item != null)
            {
                return CreatedAtRoute("id", new { id = item.Id }, item);
            }

            return BadRequest("Failed saving Instruction");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Guid?>> Update(Instructions instructions, string id)
        {
            var itemId = await _mediator.Send(new EditInstructionCommand() {instructionsDto=instructions, Id = id });
            if (itemId != null)
            {
                return Ok(itemId);
            }

            return BadRequest("Instruction not found");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid?>> Delete(string id)
        {
            var itemId = await _mediator.Send(new DeleteInstructionCommand() { InstructionId = id });
            if (itemId != null)
            {
                return Ok(itemId);
            }

            return BadRequest("Instruction not found");
        }
    }
}
