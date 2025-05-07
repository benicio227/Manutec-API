using Manutec.Core.Enums;

namespace Manutec.Core.Entities;
public class User
{
    public int Id {  get; private set; }
    public string UserName {  get; private set; }
    public string PasswordHash {  get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public int WorkShopId {  get; private set; }
    public WorkShop WorkShop {  get; private set; }

    public UserRole Role { get; private set; }
}
