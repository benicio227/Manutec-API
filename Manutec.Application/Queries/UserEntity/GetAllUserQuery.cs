using Manutec.Application.Models;
using Manutec.Application.Models.UserModel;
using Manutec.Core.Entities;
using MediatR;

namespace Manutec.Application.Queries.UserEntity;
public class GetAllUserQuery : IRequest<ResultViewModel<List<GetAllUserViewModel>>>
{
    public int WorkShopId {  get; set; }
}
