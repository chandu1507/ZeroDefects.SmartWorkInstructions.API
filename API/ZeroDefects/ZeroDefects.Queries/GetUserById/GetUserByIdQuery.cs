using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroDefects.Domain.Dtos;
using ZeroDefects.Domain.Entities;

namespace ZeroDefects.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<IEnumerable<User>>
    {
        public string Id { get; set; }
    }
}
