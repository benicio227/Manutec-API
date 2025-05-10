using Manutec.Application.Models;
using Manutec.Core.Entities;
using MediatR;

namespace Manutec.Application.Queries.UserEntity;
public class GetByIdUserQuery : IRequest<User>
{
    public GetByIdUserQuery(int workShopId, int id)
    {
        WorkShopId = workShopId;
        Id = id;
    }

    public int WorkShopId {  get; set; }
    public int Id {  get; set; }
}
