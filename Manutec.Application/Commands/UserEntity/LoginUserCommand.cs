using Manutec.Application.Models;
using Manutec.Application.Models.UserModel;
using Manutec.Core.Enums;
using MediatR;

namespace Manutec.Application.Commands.UserEntity;
public class LoginUserCommand : IRequest<ResultViewModel<LoginViewModel>>
{
    public string Email {  get; set; }
    public string Password { get; set; }
}
