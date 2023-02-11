using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZeroDefects.Commands.AddInstruction;
using ZeroDefects.Commands.CreateUser;
using ZeroDefects.Commands.DeleteInstruction;
using ZeroDefects.Commands.DeleteUser;
using ZeroDefects.Commands.EditUser;
using ZeroDefects.Domain.Dtos;
using ZeroDefects.Domain.Entities;
using ZeroDefects.Domain.Interfaces;
using ZeroDefects.Queries.GetInstructions;
using ZeroDefects.Queries.GetUserById;
using ZeroDefects.Queries.GetUsers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZeroDefects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        public UsersController(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }
        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = _userRepository.Authenticate(loginDto.UserName, loginDto.Password);
            if (token==null)
            {
                return Unauthorized();
            }
            return Ok(new { token.Result});
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            try
            {
                var items = await _mediator.Send(new GetUsersQuery());
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
        // GET: api/<UsersController>
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            try
            {
                var item = await _mediator.Send(new GetUserByIdQuery() { Id = id });
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

        

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] CreateUserCommand command)
        {
            var item = await _mediator.Send(command);
            if (item != null)
            {
                return CreatedAtRoute("id", new { id = item.Id }, item);
            }

            return BadRequest("Failed saving User");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string?>> Update(User user, string id)
        {
            var itemId = await _mediator.Send(new EditUserCommand() { userDto = user, Id = id });
            if (itemId != null)
            {
                return Ok(itemId);
            }

            return BadRequest("User not found");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string?>> Delete(string id)
        {
            var itemId = await _mediator.Send(new DeleteUserCommand() { Id = id });
            if (itemId != null)
            {
                return Ok(itemId);
            }

            return BadRequest("Instruction not found");
        }
    }
}
