using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.ViewModels;
using DevFreela.Core;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            
        // Utilizar o mesmo algoritmo para criar o hash dessa senha
        var passwordHash = _authService.ComputeSha256Hash(request.Password);
        // Buscar no meu banco de dados um User que tenha meu e-mail e minha senha em formato hash
        var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

        // Se nao existir, erro no login
        if (user == null)
        {
            return null;
        }
        // Se existir, gero o token usando os dados do usuário
        var token = _authService.GenerateJwtToken(user.Email, user.Role);
        return new LoginUserViewModel(user.Email, token);

        }
    }
}