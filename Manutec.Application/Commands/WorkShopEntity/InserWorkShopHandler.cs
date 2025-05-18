using Manutec.Application.Models;
using Manutec.Application.Models.WorkShopModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.WorkShopEntity;
public class InserWorkShopHandler : IRequestHandler<InsertWorkShopCommand, ResultViewModel<WorkShopViewModelId>>
{
    private readonly IWorkShopRepository _workShopRepository;

    public InserWorkShopHandler(IWorkShopRepository workShopRepository)
    {
        _workShopRepository = workShopRepository;
    }
    public async Task<ResultViewModel<WorkShopViewModelId>> Handle(InsertWorkShopCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var workShop = request.ToEntity();

            var existWorkShop = await _workShopRepository.Add(workShop);

            if (existWorkShop is null)
            {
                return ResultViewModel<WorkShopViewModelId>.Error("Oficina não encontrada.");
            }

            return ResultViewModel<WorkShopViewModelId>.Success(new WorkShopViewModelId(existWorkShop.Id));
        }
        catch (Exception ex)
        {
            return ResultViewModel<WorkShopViewModelId>.Error($"Erro interno: {ex.Message}");
        }
    }
}
