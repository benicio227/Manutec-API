using Manutec.Application.Models;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.CustomerEntity;
public class GetByIdCustomerHandler : IRequestHandler<GetByIdCustomerQuery, CustomerViewModel>
{
    private readonly ICustomerRepository _customerRepository;
    public GetByIdCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<CustomerViewModel> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(request.WorkShopId, request.Id);

        if (customer is null)
        {
            throw new Exception("Nenhum cliente encontrado");
        }

        var model = CustomerViewModel.FromEntity(customer);

        return model;
    }
}
