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

        var workShop = request.ToEntity();

        var emailExist = await _workShopRepository.EmailExists(request.Email);

        if (emailExist is not null)
        {
            return ResultViewModel<WorkShopViewModelId>.Error("Email já cadastrado");
        }

        var existWorkShop = await _workShopRepository.Add(workShop);

        if (existWorkShop is null)
        {
            return ResultViewModel<WorkShopViewModelId>.Error("Oficina não encontrada.");
        }


        var model = WorkShopViewModelId.FromEntity(existWorkShop);

        return ResultViewModel<WorkShopViewModelId>.Success(model);
    }
}
