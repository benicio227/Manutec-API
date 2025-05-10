using Manutec.Core.Enums;

namespace Manutec.Core.Entities;
public class User
{
    public User(string userName, int workShopId, string passwordHash, string email, string phone, UserRole role)
    {
        UserName = userName;
        WorkShopId = workShopId;
        PasswordHash = passwordHash;
        Email = email;
        Phone = phone;
        Role = role;

        CreatedAt = DateTime.Now;
        IsDeleted = false;
    }
    public int Id {  get; private set; }
    public string UserName {  get; private set; }
    public string PasswordHash {  get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsDeleted {  get; private set; }
    public int WorkShopId {  get; private set; }
    public WorkShop WorkShop {  get; private set; }

    public UserRole Role { get; private set; }

    public void UpdateName(string name)
    {
        UserName = name;
    }

    public void UpdateEmail(string email)
    {
        Email = email;
    }

    public void UpdatePhone(string phone)
    {
        Phone = phone;
    }
    
    public void UpdatePassword(string password)
    {
        PasswordHash = password;
    }

    public void Deleted()
    {
        IsDeleted = true;
    }
}
