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

namespace ZeroDefects.Commands.CreateInstruction
{
    public class CreateInstructionHandler : IRequestHandler<CreateInstructionCommand, InstructionsDto>
    {
        private readonly IInstructionsRepository _instructionsRepository;
        private readonly IMapper _mapper;

        public CreateInstructionHandler(IInstructionsRepository instructionsRepository, IMapper mapper)
        {
            _instructionsRepository = instructionsRepository;
            _mapper = mapper;
        }

        public async Task<InstructionsDto> Handle(CreateInstructionCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Instructions>(request);

            await _instructionsRepository.AddInstructionAsync(item);

            return _mapper.Map<InstructionsDto>(item);
        }
    }
}
