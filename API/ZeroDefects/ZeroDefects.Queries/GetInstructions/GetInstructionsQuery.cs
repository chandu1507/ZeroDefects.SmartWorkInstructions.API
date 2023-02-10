using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroDefects.Domain.Dtos;
using ZeroDefects.Domain.Entities;

namespace ZeroDefects.Queries.GetInstructions
{
    public class GetInstructionsQuery : IRequest<IEnumerable<Instructions>>
    {
    }
}
