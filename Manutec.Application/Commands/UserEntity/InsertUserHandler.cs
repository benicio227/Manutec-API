using Manutec.Application.Models;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.UserEntity;
public class InsertUserHandler : IRequestHandler<InsertUserCommand, UserViewModel>
{
    private readonly IUserRepository _userRepository;
    public InsertUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<UserViewModel> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToEntity();

        var existUser = await _userRepository.Add(user);

        if (existUser is null)
        {
            throw new Exception("Erro ao cadastrar usuário.");
        }

        var model = UserViewModel.FromEntity(user);

        return model;
    }
}
