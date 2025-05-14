using Manutec.Core.Entities;
using Manutec.Core.Enums;

namespace Manutec.Application.Models.UserModel;
public class UserViewModel
{
    public UserViewModel(int id, string userName, string email, string phone, UserRole role)
    {
        Id = id;
        UserName = userName;
        Email = email;
        Phone = phone;
        CreatedAt = DateTime.Now;
        Role = role;
    }
    public int Id { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public UserRole Role { get; private set; }

    public static UserViewModel FromEntity(User user)
    {
        return new UserViewModel(user.Id, user.UserName, user.Email, user.Phone, user.Role);
    }
}
