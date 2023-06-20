using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandle : IRequestHandler<CreateUserCommand, int>
    {
     private readonly IUserRepository _userRepository;
        
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FullName, request.Email, request.BirthDate);
            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}