using Manutec.Application.Models;
using Manutec.Core.Entities;
using MediatR;

namespace Manutec.Application.Queries.UserEntity;
public class GetAllUserQuery : IRequest<List<User>>
{
    public int WorkShopId {  get; set; }
}
