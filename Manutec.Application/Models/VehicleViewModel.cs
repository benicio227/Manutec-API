using Manutec.Core.Entities;

namespace Manutec.Application.Models;
public class VehicleViewModel
{
    public VehicleViewModel(string brand, string model, int year, string licensePlate, int currentMileage)
    {
        Brand = brand;
        Model = model;
        Year = year;
        LicensePlate = licensePlate;
        CurrentMileage = currentMileage;
    }

    public string Brand { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    public string LicensePlate { get; private set; }
    public int CurrentMileage { get; private set; }

    public static VehicleViewModel FromEntity(Vehicle vehicle)
    {
        return new VehicleViewModel(vehicle.Brand, vehicle.Model, vehicle.Year, vehicle.LicensePlate, vehicle.CurrentMileage);
    }
}
