using Manutec.Application.Models;
using Manutec.Application.Models.WorkShopModel;
using Manutec.Core.Entities;
using MediatR;

namespace Manutec.Application.Queries.WorkShopEntity;
public class GetByIdWorkShopQuery : IRequest<ResultViewModel<WorkShopViewModel>>
{
    public int Id { get; set; }
}
