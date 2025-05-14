using Manutec.Core.Entities;

namespace Manutec.Application.Models.UserModel;
public class UserViewModel
{
    public UserViewModel(int id)
    {
        Id = id;
    }
    public int Id { get; private set; }

    public static UserViewModel FromEntity(User user)
    {
        return new UserViewModel(user.Id);
    }
}
