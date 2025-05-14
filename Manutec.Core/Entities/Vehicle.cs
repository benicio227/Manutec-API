namespace Manutec.Core.Entities;
public class Vehicle
{
    public Vehicle(int customerId, int workShopId, string brand, string model, int year, string licensePlate, int currentMileage, int toleranceKm)
    {
        CustomerId = customerId;
        WorkShopId = workShopId;
        Brand = brand;
        Model = model;
        Year = year;
        LicensePlate = licensePlate;
        CurrentMileage = currentMileage;

        CreatedAt = DateTime.Now;
        IsDeleted = false;

        Maintenances = new List<Maintenance>();
        ToleranceKm = toleranceKm;  
    }
    public int Id { get; private set; }
    public int CustomerId {  get; private set; }
    public int WorkShopId {  get; private set; }
    public string Brand {  get; private set; }
    public string Model {  get; private set; }
    public int Year {  get; private set; }
    public string LicensePlate {  get; private set; }
    public int CurrentMileage {  get; private set; }
    public int ToleranceKm {  get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Customer Customer { get; private set; }
    public WorkShop WorkShop { get; private set; }
    public ICollection<Maintenance> Maintenances { get; set; }

    public void UpdateBrand(string nameBrand)
    {
        Brand = nameBrand;
    }

    public void UpdateModel(string nameModel)
    {
        Model = nameModel;
    }

    public void UpdateYear(int year)
    {
        Year = year;
    }

    public void UpdateLisencePlate(string lisensePlate)
    {
        LicensePlate = lisensePlate;
    }
    public void UpdateCurrentMileage(int currentMileage)
    {
        CurrentMileage = currentMileage;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}
