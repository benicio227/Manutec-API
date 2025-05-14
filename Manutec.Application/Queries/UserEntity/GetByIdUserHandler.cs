using Manutec.Application.Models;
using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.UserEntity;
public class GetByIdUserHandler : IRequestHandler<GetByIdUserQuery, ResultViewModel<User>>
{
    private readonly IUserRepository _userRepository;

    public GetByIdUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<ResultViewModel<User>> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.WorkShopId, request.Id);

        if (user == null)
        {
            return ResultViewModel<User>.Error("Nenhum usuário encontrado");
        }

        return ResultViewModel<User>.Success(user);
    }
}
