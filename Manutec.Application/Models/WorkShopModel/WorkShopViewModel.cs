using Manutec.Core.Entities;

namespace Manutec.Application.Models.WorkShopModel;
public class WorkShopViewModel
{
    public WorkShopViewModel(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public static WorkShopViewModel FromEntity(WorkShop workshop)
    {
        return new WorkShopViewModel(workshop.Name, workshop.Email, workshop.Phone);
    }
}
