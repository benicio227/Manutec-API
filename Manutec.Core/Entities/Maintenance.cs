using Manutec.Core.Enums;

namespace Manutec.Core.Entities;
public class Maintenance
{
    public Maintenance(int vehicleId, int workShopId, MaintenanceType type, DateTime scheduledDate,
        int scheduledMileage, DateTime? performedDate, int? performedMileage, decimal cost, string description)
    {
        VehicleId = vehicleId;
        WorkShopId = workShopId;
        Type = type;
        ScheduledDate = scheduledDate;
        ScheduledMileage = scheduledMileage;
        PerformedDate = performedDate;
        PerformedMileage = performedMileage;
        Cost = cost;
        Description = description;

        IsCompleted = false;
        IsDeleted = false;
        CreatedAt = DateTime.Now;
    }
    public int Id { get; private set; }
    public int VehicleId {  get; private set; }
    public int WorkShopId {  get; private set; }
    public MaintenanceType Type {  get; private set; }
    public DateTime ScheduledDate {  get; private set; }
    public int ScheduledMileage { get; private set; }
    public DateTime? PerformedDate { get; private set; }
    public int? PerformedMileage { get; private set; }
    public decimal Cost { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }
    public bool IsDeleted {  get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Vehicle Vehicle { get; private set; }
    public WorkShop WorkShop { get; private set; }

    public void UpdateType(MaintenanceType type)
    {
        Type = type;
    }

    public void UpdateScheduledDate(DateTime scheduledDate)
    {
        ScheduledDate = scheduledDate;
    }

    public void UpdateScheduledMileage(int scheduledMileage)
    {
        ScheduledMileage = scheduledMileage;
    }

    public void UpdatePerformedDate(DateTime performedDate)
    {
        PerformedDate = performedDate;
    }
    public void UpdatePerfomedMileage(int performedMileage)
    {
        PerformedMileage = performedMileage;
    }
    public void UpdateCost(decimal cost)
    {
        Cost = cost;
    }

    public void UpdateDescription(string description)
    {
        Description = description;
    }
    public void Delete()
    {
        IsDeleted = true;
    }
    public void Completed()
    {
        IsCompleted = true;
    }

}
