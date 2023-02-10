using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroDefects.Domain.Dtos;
using ZeroDefects.Domain.Entities;

namespace ZeroDefects.Commands.AddInstruction
{
    public class EditInstructionCommand : IRequest<Instructions>
    {
        public string Id { get; set; }
        public Instructions instructionsDto { get; set; }
    }
}
