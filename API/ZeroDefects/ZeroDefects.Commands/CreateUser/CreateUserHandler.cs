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

namespace ZeroDefects.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<User>(request);

            await _userRepository.AddUserAsync(item);

            return _mapper.Map<UserDto>(item);
        }
    }
}
