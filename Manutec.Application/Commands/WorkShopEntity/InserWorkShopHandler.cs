using Manutec.Application.Models;
using Manutec.Application.Models.WorkShopModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.WorkShopEntity;
public class InserWorkShopHandler : IRequestHandler<InsertWorkShopCommand, ResultViewModel<WorkShopViewModel>>
{
    private readonly IWorkShopRepository _workShopRepository;

    public InserWorkShopHandler(IWorkShopRepository workShopRepository)
    {
        _workShopRepository = workShopRepository;
    }
    public async Task<ResultViewModel<WorkShopViewModel>> Handle(InsertWorkShopCommand request, CancellationToken cancellationToken)
    {
        var workShop = request.ToEntity();

        var existWorkShop = await _workShopRepository.Add(workShop);

        if (existWorkShop is null)
        {
            return ResultViewModel<WorkShopViewModel>.Error("Oficina não encontrada.");
        }

        return ResultViewModel<WorkShopViewModel>.Success(new WorkShopViewModel(workShop.Id));
    }
}
