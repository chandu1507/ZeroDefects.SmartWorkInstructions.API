using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZeroDefects.Domain.Dtos;

namespace ZeroDefects.Commands.AddInstruction
{
    public class CreateInstructionCommand : IRequest<InstructionsDto>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Progress { get; set; }
        public bool Isactive { get; set; }
        public string CreatedDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Image { get; set; }
    }
}
