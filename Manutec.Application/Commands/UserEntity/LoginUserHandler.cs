using Manutec.Application.Models;
using Manutec.Application.Models.UserModel;
using Manutec.Core.Repositories;
using Manutec.Infrastructure.Auth;
using MediatR;

namespace Manutec.Application.Commands.UserEntity;
public class LoginUserHandler : IRequestHandler<LoginUserCommand, ResultViewModel<LoginViewModel>>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;
    public LoginUserHandler(IAuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }
    public async Task<ResultViewModel<LoginViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var hash = _authService.ComputeHash(request.Password);

        var user = await _userRepository.GetByEmailAndPassword(request.Email, hash);

        if (user is null)
        {
            return ResultViewModel<LoginViewModel>.Error("Usuário não encontrado");
        }

        var token = _authService.GenerateToken(user.Email, user.Role, user.WorkShopId);

        var viewModel = new LoginViewModel(token);

        return ResultViewModel<LoginViewModel>.Success(viewModel);
    }
}
