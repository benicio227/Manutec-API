using Manutec.Application.Models;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.UserEntity;
public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.WorkShopId, request.Id);

        if (user is null)
        {
            return ResultViewModel.Error("Usuário não encontrado");
        }

        await _userRepository.Delete(user);

        return ResultViewModel.Success();
    }
}
