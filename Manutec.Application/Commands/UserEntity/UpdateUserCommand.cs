using Manutec.Application.Models;
using Manutec.Core.Entities;
using Manutec.Core.Enums;
using MediatR;

namespace Manutec.Application.Commands.UserEntity;
public class UpdateUserCommand : IRequest<UpdateViewModel>
{
    public int Id {  get; set; }
    public string UserName { get; set; }
    public int WorkShopId {  get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public UserRole Role { get; set; }
    public User ToEntity()
    {
        return new User(UserName, WorkShopId, PasswordHash, Email, Phone, Role);
    }
}
