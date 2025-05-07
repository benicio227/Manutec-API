namespace Manutec.Core.Entities;
public class Vehicle
{
    public int Id { get; private set; }
    public int CustomerId {  get; private set; }
    public int WorkShopId {  get; private set; }
    public string Brand {  get; private set; }
    public string Model {  get; private set; }
    public int Year {  get; private set; }
    public string LicensePlate {  get; private set; }
    public int CurrentMileage {  get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Customer Customer { get; private set; }
    public WorkShop WorkShop { get; private set; }
    public ICollection<Maintenance> Maintenances { get; set; }
}
