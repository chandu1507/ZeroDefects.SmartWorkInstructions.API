using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZeroDefects.Domain.Dtos;

namespace ZeroDefects.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
