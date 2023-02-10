using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroDefects.Commands.AddInstruction;
using ZeroDefects.Domain.Dtos;
using ZeroDefects.Domain.Entities;
using ZeroDefects.Domain.Interfaces;

namespace ZeroDefects.Commands.EditInstruction
{
    public class EditInstructionHandler:IRequestHandler<EditInstructionCommand, Instructions>
    {
        private readonly IInstructionsRepository _instructionsRepository;
        private readonly IMapper _mapper; 
        public EditInstructionHandler(IInstructionsRepository instructionsRepository)
        {
            _instructionsRepository = instructionsRepository;
        }

        public async Task<Instructions> Handle(EditInstructionCommand request, CancellationToken cancellationToken)
        {          

            return await _instructionsRepository.UpdateInstructionAsync(request.instructionsDto);
        }
    }
}
