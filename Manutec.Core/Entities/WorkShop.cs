namespace Manutec.Core.Entities;
public class WorkShop
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email {  get; private set; }
    public string Phone {  get; private set; }
    public DateTime CreatedAt {  get; private set; }

    public ICollection<User> Users { get; private set; }
    public ICollection<Customer> Customers { get; private set; }
    public ICollection<Vehicle> Vehicles { get; private set; }

}
