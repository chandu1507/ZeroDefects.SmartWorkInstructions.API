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

namespace ZeroDefects.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, string?>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<string?> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
           
            return await _userRepository.DeleteUserAsync(request.Id); 
        }
    }
}
