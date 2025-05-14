using Manutec.Application.Models;
using Manutec.Application.Models.CustomerModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Commands.CustomerEntity;
public class InsertCustomerHandler : IRequestHandler<InsertCustomerCommand, ResultViewModel<CustomerViewModel>>
{
    private readonly ICustomerRepository _customerRepository;

    public InsertCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<ResultViewModel<CustomerViewModel>> Handle(InsertCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = request.ToEntity();

        var existCustomer = await _customerRepository.Add(customer);

        if (existCustomer is null)
        {
            return ResultViewModel<CustomerViewModel>.Error("Não foi possível cadastrar o cliente.");
        }

        var model = CustomerViewModel.FromEntity(customer);

        return ResultViewModel<CustomerViewModel>.Success(model);
    }
}
