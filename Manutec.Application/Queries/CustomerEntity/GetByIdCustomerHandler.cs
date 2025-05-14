using Manutec.Application.Models;
using Manutec.Application.Models.CustomerModel;
using Manutec.Core.Repositories;
using MediatR;

namespace Manutec.Application.Queries.CustomerEntity;
public class GetByIdCustomerHandler : IRequestHandler<GetByIdCustomerQuery, ResultViewModel<CustomerViewModel>>
{
    private readonly ICustomerRepository _customerRepository;
    public GetByIdCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<ResultViewModel<CustomerViewModel>> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(request.WorkShopId, request.Id);

        if (customer is null)
        {
            return ResultViewModel<CustomerViewModel>.Error("Nenhum cliente encontrado");
        }

        var model = CustomerViewModel.FromEntity(customer);

        return ResultViewModel<CustomerViewModel>.Success(model);
    }
}
