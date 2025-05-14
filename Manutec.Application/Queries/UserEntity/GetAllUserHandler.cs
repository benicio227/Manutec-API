using Manutec.Application.Models;
using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.UserEntity;
public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, ResultViewModel<List<User>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<ResultViewModel<List<User>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllByWorkShopId(request.WorkShopId);

        return ResultViewModel<List<User>>.Success(users);
    }
}
