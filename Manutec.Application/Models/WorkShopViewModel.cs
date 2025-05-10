using Manutec.Core.Entities;

namespace Manutec.Application.Models;
public class WorkShopViewModel
{
    public WorkShopViewModel(int id, string name, string email, string phone)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
    }
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public static WorkShopViewModel FromEntity(WorkShop workShop)
    {
        return new WorkShopViewModel(workShop.Id, workShop.Name, workShop.Email, workShop.Phone);
    }
}
