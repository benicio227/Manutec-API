using Manutec.Core.Entities;

namespace Manutec.Application.Models.UserModel;
public class GetAllUserViewModel
{
    public GetAllUserViewModel(string userName, string email, string phone, DateTime createdAt)
    {
        UserName = userName;
        Email = email;
        Phone = phone;
        CreatedAt = createdAt;
    }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public static List<GetAllUserViewModel> FromEntity(List<User> users)
    {
        return users.Select(user => new GetAllUserViewModel(user.UserName, user.Email, user.Phone, user.CreatedAt)).ToList();
    }
}
