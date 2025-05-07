using Manutec.Core.Enums;
using System.Runtime.InteropServices;

namespace Manutec.Core.Entities;
public class Maintenance
{
    public int Id { get; set; }
    public int VehicleId {  get; set; }
    public int WorkShopId {  get; set; }
    public MaintenanceType Type {  get; set; }
    public DateTime ScheduledDate {  get; set; }
    public DateTime? PerformedDate { get; set; }
    public int? PerformedMileage { get; set; }
    public decimal Cost { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }

    public Vehicle Vehicle { get; set; }
    public WorkShop WorkShop { get; set; }
}
