namespace Manutec.Core.Entities;
public class Customer
{
    public int Id { get; private set; }
    public int WorkShopId  { get; private set; }
    public string Name {  get; private set; }
    public string Email {  get; private set; }
    public string Phone { get; private set; }
    public DateTime CreatedAt {  get; private set; }

    public WorkShop WorkShop { get; private set; }
    public ICollection<Vehicle> Vehicles { get; private set; }
}
