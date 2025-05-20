using Manutec.Core.Entities;
using Manutec.Core.Enums;

namespace Manutec.Application.Models.UserModel;
public class GetByIdUserViewModel
{
    public GetByIdUserViewModel(string userName, string email, string phone, UserRole role, DateTime createdAt)
    {
        UserName = userName;
        Email = email;
        Phone = phone;
        Role = role;
        CreatedAt = createdAt;
    }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public UserRole Role { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public static GetByIdUserViewModel FromEntity(User user)
    {
        return new GetByIdUserViewModel(user.UserName, user.Email, user.Phone, user.Role, user.CreatedAt);
    }
}
