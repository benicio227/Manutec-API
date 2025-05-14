using Manutec.Application.Models;
using Manutec.Application.Models.UserModel;
using Manutec.Core.Repositories;
using Manutec.Infrastructure.Auth;
using MediatR;

namespace Manutec.Application.Commands.UserEntity;
public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<UserViewModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    public InsertUserHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }
    public async Task<ResultViewModel<UserViewModel>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToEntity();

        user.UpdatePassword(_authService.ComputeHash(request.PasswordHash)); 

        var existUser = await _userRepository.Add(user);

        if (existUser is null)
        {
            return ResultViewModel<UserViewModel>.Error("Erro ao cadastrar usuário.");
        }

        var model = UserViewModel.FromEntity(user);

        return ResultViewModel<UserViewModel>.Success(new UserViewModel(user.Id));
    }
}
