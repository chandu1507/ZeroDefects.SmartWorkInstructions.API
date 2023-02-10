using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroDefects.Domain.Interfaces;

namespace ZeroDefects.Commands.DeleteInstruction
{
    public class DeleteInstructionHandler:IRequestHandler<DeleteInstructionCommand,string?>
    {
        private readonly IInstructionsRepository _instructionsRepository;

        public DeleteInstructionHandler(IInstructionsRepository instructionsRepository)
        {
            _instructionsRepository = instructionsRepository;
        }

        public async Task<string?> Handle(DeleteInstructionCommand request, CancellationToken cancellationToken)
        {
            return await _instructionsRepository.DeleteInstructionAsync(request.InstructionId);
        }
    }
}
