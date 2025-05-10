using Manutec.Application.Models;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.CustomerEntity;
public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerViewModel>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<UpdateCustomerViewModel> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = request.ToEntity();

        var customerExist = await _customerRepository.GetById(request.WorkShopId, request.Id);

        if (customerExist is null)
        {
            throw new Exception("Cliente não encontrado");
        }


        customerExist.UpdateName(customer.Name);
        customerExist.UpdateEmail(customer.Email);
        customerExist.UpdatePhone(customer.Phone);

        await _customerRepository.Update(customerExist);

        var model = UpdateCustomerViewModel.FromEntity(customer);

        return model;
    }
}
