namespace Manutec.Core.Entities;
public class Customer
{
    public Customer(int workShopId, string name, string email, string phone)
    {
        WorkShopId = workShopId;
        Name = name;
        Email = email;
        Phone = phone;

        CreatedAt = DateTime.Now;
        IsDeleted = false;

        Vehicles = new List<Vehicle>();
    }
    public int Id { get; private set; }
    public int WorkShopId  { get; private set; }
    public string Name {  get; private set; }
    public string Email {  get; private set; }
    public string Phone { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt {  get; private set; }

    public WorkShop WorkShop { get; private set; }
    public ICollection<Vehicle> Vehicles { get; private set; }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void UpdateEmail(string email)
    {
        Email = email;
    }

    public void UpdatePhone(string phone)
    {
        Phone = phone;
    }

    public void Delete()
    {
        IsDeleted = true;
    }

}
