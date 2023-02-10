using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroDefects.Domain.Dtos;
using ZeroDefects.Domain.Entities;

namespace ZeroDefects.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
