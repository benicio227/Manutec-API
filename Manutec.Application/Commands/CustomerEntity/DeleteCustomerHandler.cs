using Manutec.Application.Models;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.CustomerEntity;
public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, ResultViewModel>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<ResultViewModel> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(request.WorkShopId, request.Id);

        if (customer is null)
        {
            return ResultViewModel.Error("Cliente não encontrado");
        }

        await _customerRepository.Delete(customer);

        return ResultViewModel.Success();
    }
}
