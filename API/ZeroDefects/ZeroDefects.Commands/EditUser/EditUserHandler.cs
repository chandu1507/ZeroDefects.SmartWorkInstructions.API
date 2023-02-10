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

namespace ZeroDefects.Commands.EditUser
{
    public class EditUserHandler : IRequestHandler<EditUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public EditUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<User>(request);            

            return await _userRepository.UpdateUserAsync(request.userDto);
        }
    }
}
