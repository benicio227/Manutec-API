namespace Manutec.Core.Entities;
public class WorkShop
{
    public WorkShop(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;

        CreatedAt = DateTime.Now;
        IsDeleted = false;

        Users = new List<User>();
        Customers = new List<Customer>();
        Vehicles = new List<Vehicle>();
        Maintenances = new List<Maintenance>();
    }
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email {  get; private set; }
    public string Phone {  get; private set; }
    public bool IsDeleted { get; private set; } 
    public DateTime CreatedAt {  get; private set; }

    public ICollection<User> Users { get; private set; }
    public ICollection<Customer> Customers { get; private set; }
    public ICollection<Vehicle> Vehicles { get; private set; }
    public ICollection<Maintenance> Maintenances { get; private set; }

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
