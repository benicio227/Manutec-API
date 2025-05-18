using Manutec.Application.Commands.VehicleEntity;
using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using NSubstitute;

namespace Manutec.UnitTests.Application;
public class UpdateVehicleHandlerTests
{
    [Fact]
    public async Task VehicleExists_UpdatesSuccessfully_ReturnsSuccess()
    {
        // Arrange
        var repository = Substitute.For<IVehicleRepository>();

        var existingVehicle = new Vehicle(
            customerId: 1,
            workShopId: 1,
            brand: "Toyota",
            model: "Corolla",
            year: 2020,
            licensePlate: "ABC1D23",
            currentMileage: 10000,
            toleranceKm: 500
        );

        repository.GetById(1, 1, 1).Returns(existingVehicle);

        var command = new UpdateVehicleCommand
        {
            Id = 1,
            CustomerId = 1,
            WorkShopId = 1,
            Brand = "Honda",
            Model = "Civic",
            Year = 2023,
            LicensePlate = "ABC1D23",
            CurrentMileage = 15000,
            ToleranceKm = 500
        };

        var handler = new UpdateVehicleHandler(repository);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(2023, existingVehicle.Year);
        Assert.Equal("Honda", existingVehicle.Brand);
        Assert.Equal(15000, existingVehicle.CurrentMileage);
        await repository.Received(1).Update(existingVehicle);
    }

    [Fact]
    public async Task VehicleNotFound_ReturnsError()
    {
        // Arrange
        var repository = Substitute.For<IVehicleRepository>();

        repository.GetById(1, 1, 99).Returns((Vehicle)null);

        var command = new UpdateVehicleCommand
        {
            Id = 99,
            CustomerId = 1,
            WorkShopId = 1,
            Brand = "Honda",
            Model = "Civic",
            Year = 2023,
            LicensePlate = "ABC1D23",
            CurrentMileage = 15000,
            ToleranceKm = 500
        };

        var handler = new UpdateVehicleHandler(repository);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Veículo não encontrado", result.Message);

        await repository.DidNotReceive().Update(Arg.Any<Vehicle>());
    }
}
