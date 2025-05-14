using Manutec.Application.Models;
using Manutec.Application.Models.VehicleModel;
using Manutec.Core.Entities;
using MediatR;

namespace Manutec.Application.Commands.VehicleEntity;
public class InsertVehicleCommand : IRequest<ResultViewModel<VehicleViewModel>>
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int WorkShopId { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string LicensePlate { get; set; }
    public int CurrentMileage { get; set; }
    public int ToleranceKm {  get; set; }

    public Vehicle ToEntity()
    {
        return new Vehicle(CustomerId, WorkShopId, Brand, Model, Year, LicensePlate, CurrentMileage, ToleranceKm);
    }
}
