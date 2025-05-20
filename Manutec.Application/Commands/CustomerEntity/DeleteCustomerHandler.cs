using Manutec.Application.Models;
using Manutec.Application.Models.CustomerModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.CustomerEntity;
public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, ResultViewModel<CustomerViewModel>>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<ResultViewModel<CustomerViewModel>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(request.WorkShopId, request.Id);

        if (customer is null)
        {
            return ResultViewModel<CustomerViewModel>.Error("Cliente não encontrado");
        }

        if (customer.IsDeleted)
        {
            return ResultViewModel<CustomerViewModel>.Error("Cliente já foi excluído.");
        }

        await _customerRepository.Delete(customer);

        var model = CustomerViewModel.FromEntity(customer);

        return ResultViewModel<CustomerViewModel>.Success(model);
    }
}
