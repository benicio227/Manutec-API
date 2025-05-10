using MediatR;
using System.Runtime.CompilerServices;

namespace Manutec.Application.Commands.UserEntity;
public class DeleteUserCommand : IRequest<Unit>
{
    public DeleteUserCommand(int id, int workShopId)
    {
        Id = id;
        WorkShopId = workShopId;
    }
    public int Id { get; set; }
    public int WorkShopId {  get; set; }
}
