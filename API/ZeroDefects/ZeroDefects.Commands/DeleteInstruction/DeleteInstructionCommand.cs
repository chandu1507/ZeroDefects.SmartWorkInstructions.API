using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroDefects.Commands.DeleteInstruction
{
    public class DeleteInstructionCommand : IRequest<string?>
    {
        public string InstructionId { get; set; }
    }
}
