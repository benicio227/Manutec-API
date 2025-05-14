using Manutec.Application.Models;
using Manutec.Application.Models.UserModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.UserEntity;
public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel<UpdateUserViewModel>>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<ResultViewModel<UpdateUserViewModel>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {

        var user = request.ToEntity();

        var existUser = await _userRepository.GetById(request.WorkShopId, request.Id);

        if (existUser is null)
        {
            return ResultViewModel<UpdateUserViewModel>.Error("Usuário não encontrado");
        }

        existUser.UpdateName(request.UserName);
        existUser.UpdateEmail(request.Email);
        existUser.UpdatePhone(request.Phone);
        existUser.UpdatePassword(request.PasswordHash);

        await _userRepository.Update(existUser);

        var model = UpdateUserViewModel.FromEntity(user);

        return ResultViewModel<UpdateUserViewModel>.Success(model);
    }
}
