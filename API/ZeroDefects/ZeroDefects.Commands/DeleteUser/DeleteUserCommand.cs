using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZeroDefects.Domain.Dtos;

namespace ZeroDefects.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<string?>
    {
        public string Id { get; set; }
       
    }
}
