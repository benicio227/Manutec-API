using Manutec.Application.Commands.VehicleEntity;
using Manutec.Core.Entities;
using Manutec.Core.Repositories;
using NSubstitute;

namespace Manutec.UnitTests.Application;
public class InsertVehicleHandlerTests
{
    [Fact]
    public async Task InputDataAreOk_Insert_Success() // Se todos os dados estiverem corretos e a placa não existir na oficina, o veículo deve ser cadastrado com secesso
    {
        //Arrange
        var repository = Substitute.For<IVehicleRepository>(); // Simula o acesso ao banco de dados sem precisar de banco real

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

        // Quando o método Add for chamado, ele vai retornar um veículo válido(simulando que o banco salvou))
        repository.Add(Arg.Any<Vehicle>()).Returns(Task.FromResult(vehicle));

        var command = new InsertVehicleCommand
        {
            CustomerId = 1,
            WorkShopId = 1,
            Brand = "Toyota",
            Model = "Corolla",
            Year = 2022,
            LicensePlate = "ABC1D23",
            CurrentMileage = 10000,
            ToleranceKm = 500
        };

        var handler = new InsertVehicleHandler(repository);

        //Act

        // O Handler vai simular a criação do veículo e retornar o resultado
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.True(result.IsSuccess);

        // Verifica se o método Add() do repositório foi chamado extamente 1 vez, como deveria.
        await repository.Received(1).Add(Arg.Any<Vehicle>());
    }

    [Fact]
    public async Task LicensePlateAlreadyExists_ReturnsError()
    {
        //Arrange
        var repository = Substitute.For<IVehicleRepository>();

        repository.ExistsWithSamePlateInWorkShop("ABC1D23", 1).Returns(true);

        var command = new InsertVehicleCommand
        {
            CustomerId = 1,
            WorkShopId = 1,
            Brand = "Toyota",
            Model = "Corolla",
            Year = 2022,
            LicensePlate = "ABC1D23",
            CurrentMileage = 10000,
            ToleranceKm = 500
        };

        var handler = new InsertVehicleHandler(repository);

        // Act
        var result = await handler.Handle(command, new CancellationToken());

        Assert.False(result.IsSuccess);
        Assert.Equal("Já existe um veículo com essa placa registrado nessa oficina.", result.Message);
    }

    [Fact]
    public async Task AddReturnNull_ReturnsError()
    {
        var repository = Substitute.For<IVehicleRepository>();

        repository.ExistsWithSamePlateInWorkShop("ABC1D23", 1).Returns(false);

        repository.Add(Arg.Any<Vehicle>()).Returns((Vehicle)null);

        var command = new InsertVehicleCommand
        {
            CustomerId = 1,
            WorkShopId = 1,
            Brand = "Toyota",
            Model = "Corolla",
            Year = 2022,
            LicensePlate = "ABC1D23",
            CurrentMileage = 10000,
            ToleranceKm = 500
        };

        var handler = new InsertVehicleHandler(repository);

        var result = await handler.Handle(command, new CancellationToken());

        Assert.False(result.IsSuccess);
        Assert.Equal("Veículo não cadastrado.", result.Message);
    }
}
