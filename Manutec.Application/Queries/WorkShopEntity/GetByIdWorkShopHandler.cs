using Manutec.Application.Models;
using Manutec.Application.Models.WorkShopModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.WorkShopEntity;
public class GetByIdWorkShopHandler : IRequestHandler<GetByIdWorkShopQuery, ResultViewModel<WorkShopViewModel>>
{
    private readonly IWorkShopRepository _workShopRepository;

    public GetByIdWorkShopHandler(IWorkShopRepository workShopRepository)
    {
        _workShopRepository = workShopRepository;
    }
    public async Task<ResultViewModel<WorkShopViewModel>> Handle(GetByIdWorkShopQuery request, CancellationToken cancellationToken)
    {
        var workShop = await _workShopRepository.GetById(request.Id);

        if (workShop is null)
        {
            return ResultViewModel<WorkShopViewModel>.Error("Oficina não encontrada.");
        }

        var model = WorkShopViewModel.FromEntity(workShop);

        return ResultViewModel<WorkShopViewModel>.Success(model);
    }
}
