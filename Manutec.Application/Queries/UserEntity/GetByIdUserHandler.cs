using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.UserEntity;
public class GetByIdUserHandler : IRequestHandler<GetByIdUserQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetByIdUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.WorkShopId, request.Id);

        if (user == null)
        {
            throw new Exception("Nenhum usuário encontrado");
        }

        return user;
    }
}
