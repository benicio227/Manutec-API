using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.UserEntity;
public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.WorkShopId, request.Id);

        if (user is null)
        {
            throw new Exception("Usuário não encontrado");
        }

        await _userRepository.Delete(user);

        return Unit.Value;
    }
}
