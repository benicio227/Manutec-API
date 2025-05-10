using Manutec.Application.Commands.UserEntity;
using Manutec.Core.Repositories;
using Manutec.Infrastructure.Persistence;
using Manutec.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Manutec;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertUserCommand>());

        var connectionString = builder.Configuration.GetConnectionString("Manutec.Cs");

        builder.Services.AddDbContext<ManutecDbContext>(o => o.UseSqlServer(connectionString));

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
        builder.Services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
        builder.Services.AddScoped<IWorkShopRepository, WorkShopRepository>();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

   
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
