using Manutec.Application.Models;
using Manutec.Application.Models.UserModel;
using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.UserEntity;
public class GetByIdUserHandler : IRequestHandler<GetByIdUserQuery, ResultViewModel<GetByIdUserViewModel>>
{
    private readonly IUserRepository _userRepository;

    public GetByIdUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<ResultViewModel<GetByIdUserViewModel>> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.WorkShopId, request.Id);

        if (user == null)
        {
            return ResultViewModel<GetByIdUserViewModel>.Error("Nenhum usuário encontrado");
        }

        var model = GetByIdUserViewModel.FromEntity(user);

        return ResultViewModel<GetByIdUserViewModel>.Success(model);
    }
}
