using Manutec.Application.Models;
using Manutec.Application.Models.UserModel;
using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.UserEntity;
public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, ResultViewModel<List<GetAllUserViewModel>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<ResultViewModel<List<GetAllUserViewModel>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllByWorkShopId(request.WorkShopId);

        var model = GetAllUserViewModel.FromEntity(users);

        return ResultViewModel<List<GetAllUserViewModel>>.Success(model);
    }
}
