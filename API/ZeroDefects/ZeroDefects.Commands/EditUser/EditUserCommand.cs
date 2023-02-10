using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZeroDefects.Domain.Dtos;
using ZeroDefects.Domain.Entities;

namespace ZeroDefects.Commands.EditUser
{
    public class EditUserCommand : IRequest<User>
    {
        public string Id { get; set; }
        public User userDto { get; set; }
       
    }
}
