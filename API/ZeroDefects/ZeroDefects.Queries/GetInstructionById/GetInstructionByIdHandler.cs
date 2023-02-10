using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroDefects.Domain.Dtos;
using ZeroDefects.Domain.Entities;
using ZeroDefects.Domain.Interfaces;

namespace ZeroDefects.Queries.GetInstructions
{
    public class GetInstructionByIdHandler : IRequestHandler<GetInstructionByIdQuery, Instructions>
    {
        private readonly IInstructionsRepository _instructionsRepository;
        private readonly IMapper _mapper;
        public GetInstructionByIdHandler(IInstructionsRepository instructionsRepository, IMapper mapper)
        {
            _instructionsRepository = instructionsRepository;
            _mapper = mapper;
        }
        public async Task<Instructions> Handle(GetInstructionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _instructionsRepository.GetInstructionAsync(request.InstructionId);
        }
    }
}
