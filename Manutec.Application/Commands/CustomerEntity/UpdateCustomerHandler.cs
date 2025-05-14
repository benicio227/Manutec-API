using Manutec.Application.Models;
using Manutec.Application.Models.CustomerModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.CustomerEntity;
public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, ResultViewModel>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<ResultViewModel> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = request.ToEntity();

        var customerExist = await _customerRepository.GetById(request.WorkShopId, request.Id);

        if (customerExist is null)
        {
            return ResultViewModel.Error("Cliente não encontrado");
        }

        customerExist.UpdateName(customer.Name);
        customerExist.UpdateEmail(customer.Email);
        customerExist.UpdatePhone(customer.Phone);

        await _customerRepository.Update(customerExist);

        var model = UpdateCustomerViewModel.FromEntity(customer);

        return ResultViewModel.Success();
    }
}
