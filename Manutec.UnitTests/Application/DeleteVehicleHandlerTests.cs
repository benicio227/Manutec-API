using Manutec.Application.Commands.VehicleEntity;
using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using NSubstitute;

namespace Manutec.UnitTests.Application;
public class DeleteVehicleHandlerTests
{
    [Fact]
    public async Task DeleteDataAreOk_Insert_Success()
    {
        var repository = Substitute.For<IVehicleRepository>();

        var vehicle = new Vehicle(
            customerId: 1,
            workShopId: 1,
            brand: "Toyota",
            model: "Corolla",
            year: 2022,
            licensePlate: "ABC1D23",
            currentMileage: 10000,
            toleranceKm: 500
        );

        repository.GetById(1, 1, 1).Returns(vehicle);

        var command = new DeleteVehicleCommand
        {
            Id = 1,
            CustomerId = 1,
            WorkShopId = 1
        };

        var handler = new DeleteVehicleHandler(repository);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.Equal(string.Empty, result.Message);
        await repository.Received(1).Delete(vehicle);
    }

    [Fact]
    public async Task VehicleNotFound_ReturnsError()
    {
        var repository = Substitute.For<IVehicleRepository>();

        repository.GetById(1, 1, 999).Returns((Vehicle)null);

        var command = new DeleteVehicleCommand
        {
            Id = 999,
            CustomerId = 1,
            WorkShopId = 1,
        };

        var handler = new DeleteVehicleHandler(repository);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal("Nehum veículo encontrado", result.Message);

        await repository.DidNotReceive().Delete(Arg.Any<Vehicle>());
    }
}
