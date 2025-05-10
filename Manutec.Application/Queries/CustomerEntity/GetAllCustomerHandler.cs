using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.CustomerEntity;
public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, List<Customer>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<List<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAllByWorkShopId(request.WorkShopId);

        return customers;
    }
}
