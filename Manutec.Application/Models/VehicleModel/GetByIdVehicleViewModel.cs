using Manutec.Core.Entities;

namespace Manutec.Application.Models.VehicleModel;
public class GetByIdVehicleViewModel
{
    public GetByIdVehicleViewModel(string brand, string model, int year, string licensePlate, int currentMileage, int toleranceKm)
    {
        Brand = brand;
        Model = model;
        Year = year;
        LicensePlate = licensePlate;
        CurrentMileage = currentMileage;
        ToleranceKm = toleranceKm;
    }

    public string Brand { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    public string LicensePlate { get; private set; }
    public int CurrentMileage { get; private set; }
    public int ToleranceKm { get; private set; }

    public static GetByIdVehicleViewModel FromEntity(Vehicle vehicle)
    {
        return new GetByIdVehicleViewModel(vehicle.Brand, vehicle.Model, vehicle.Year, vehicle.LicensePlate, vehicle.CurrentMileage, vehicle.ToleranceKm);
    }
}
