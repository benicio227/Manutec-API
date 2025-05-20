using Manutec.Application.Models;
using Manutec.Application.Models.UserModel;
using Manutec.Core.Repositories;
using Manutec.Infrastructure.Auth;
using MediatR;

namespace Manutec.Application.Commands.UserEntity;
public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel<UpdateUserViewModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public UpdateUserHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }
    public async Task<ResultViewModel<UpdateUserViewModel>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {

        var user = request.ToEntity();

        var existUser = await _userRepository.GetById(request.WorkShopId, request.Id);

        var passwordHash = _authService.ComputeHash(request.PasswordHash);

        if (passwordHash is null)
        {
            return ResultViewModel<UpdateUserViewModel>.Error("Senha não encontrada");
        }

        if (existUser is null)
        {
            return ResultViewModel<UpdateUserViewModel>.Error("Usuário não encontrado");
        }

        existUser.UpdateName(request.UserName);
        existUser.UpdateEmail(request.Email);
        existUser.UpdatePhone(request.Phone);
        existUser.UpdatePassword(passwordHash);

        await _userRepository.Update(existUser);

        var model = UpdateUserViewModel.FromEntity(user);

        return ResultViewModel<UpdateUserViewModel>.Success(model);
    }
}
