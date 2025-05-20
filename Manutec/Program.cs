using FluentValidation;
using FluentValidation.AspNetCore;
using Manutec.Api.ExceptionHandler;
using Manutec.Application.Commands.UserEntity;
using Manutec.Core.Repositories;
using Manutec.Infrastructure.Auth;
using Manutec.Infrastructure.Persistence;
using Manutec.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace Manutec;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        var jwtKey = Environment.GetEnvironmentVariable("JWT_SECRET");

        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddEnvironmentVariables() 
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets<Program>();


        var jwtSettings = builder.Configuration.GetSection("JWT");
        var issuer = jwtSettings["Issuer"];
        var audience = jwtSettings["Audience"];


        builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertUserCommand>());

        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssemblyContaining<InsertUserCommand>();

      

        builder.Services.AddExceptionHandler<ApiExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                  
                };

                o.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Token inválido: {context.Exception.Message}");
                        return Task.CompletedTask;
                    }
                };

            });


            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

       

        var connectionString = builder.Configuration.GetConnectionString("Manutec");

        builder.Services.AddDbContext<ManutecDbContext>(o => o.UseSqlServer(connectionString));

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
        builder.Services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
        builder.Services.AddScoped<IWorkShopRepository, WorkShopRepository>();
        builder.Services.AddScoped<IGeneralMaintenanceRepository, GeneralMaintenanceRepository>();

        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped<ILoggedUser, LoggedUser>();

        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

   
        if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseExceptionHandler();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();



        app.Run();
    }
}
