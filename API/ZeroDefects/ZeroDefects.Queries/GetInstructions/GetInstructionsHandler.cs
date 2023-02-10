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
    public class GetInstructionsHandler : IRequestHandler<GetInstructionsQuery, IEnumerable<Instructions>>
    {
        private readonly IInstructionsRepository _instructionsRepository;
        private readonly IMapper _mapper;
        public GetInstructionsHandler(IInstructionsRepository instructionsRepository, IMapper mapper)
        {
            _instructionsRepository = instructionsRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Instructions>> Handle(GetInstructionsQuery request, CancellationToken cancellationToken)
        {
            return await _instructionsRepository.GetAllInstructionsAsync();
        }
    }
}
