using Manutec.Core.Entities;

namespace Manutec.Application.Models;
public class UpdateViewModel
{
    public UpdateViewModel(string userName, string passwordHash, string email, string phone)
    {
        UserName = userName;
        PasswordHash = passwordHash;
        Email = email;
        Phone = phone;
    }

    public string UserName { get; private set; }
    public string PasswordHash { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public static UpdateViewModel FromEntity(User user)
    {
        return new UpdateViewModel(user.UserName, user.PasswordHash, user.Email, user.Phone);
    }
}
