using Manutec.Application.Models;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.WorkShopEntity;
public class InserWorkShopHandler : IRequestHandler<InsertWorkShopCommand, WorkShopViewModel>
{
    private readonly IWorkShopRepository _workShopRepository;

    public InserWorkShopHandler(IWorkShopRepository workShopRepository)
    {
        _workShopRepository = workShopRepository;
    }
    public async Task<WorkShopViewModel> Handle(InsertWorkShopCommand request, CancellationToken cancellationToken)
    {
        var workShop = request.ToEntity();

        var existWorkShop = await _workShopRepository.Add(workShop);

        if (existWorkShop is null)
        {
            throw new Exception("Oficina não encontrada.");
        }

        var model = WorkShopViewModel.FromEntity(workShop);

        return model;
    }
}
