using Manutec.Application.Models;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.CustomerEntity;
public class InsertCustomerHandler : IRequestHandler<InsertCustomerCommand, CustomerViewModel>
{
    private readonly ICustomerRepository _customerRepository;

    public InsertCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<CustomerViewModel> Handle(InsertCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = request.ToEntity();

        var existCustomer = await _customerRepository.Add(customer);

        var model = CustomerViewModel.FromEntity(customer);

        return model;
    }
}
