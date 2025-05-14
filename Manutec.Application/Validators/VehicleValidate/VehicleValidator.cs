using FluentValidation;
using Manutec.Application.Commands.VehicleEntity;

namespace Manutec.Application.Validators.VehicleValidate;
public class VehicleValidator : AbstractValidator<InsertVehicleCommand>
{
    public VehicleValidator()
    {
        RuleFor(v => v.CustomerId)
            .NotEmpty().GreaterThan(0).WithMessage("O id do cliente é obrigatório.");

        RuleFor(v => v.WorkShopId)
            .NotEmpty().GreaterThan(0).WithMessage("O id da oficina é obrigatório");

        RuleFor(v => v.Brand)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("A marca do veículo é obrigatória.")
            .MaximumLength(50).WithMessage("A marca deve ter no máximo 50 caracteres.");

        RuleFor(v => v.Model)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O modelo do veículo é obrigatório.")
            .MaximumLength(50).WithMessage("O modelo deve ter no máximo 50 caracteres.");

        RuleFor(v => v.Year)
           .InclusiveBetween(1900, DateTime.Now.Year + 1).WithMessage("Ano do veículo inválido.");

        RuleFor(v => v.LicensePlate)
           .Cascade(CascadeMode.Stop)
           .NotEmpty().WithMessage("A placa do veículo é obrigatória.")
           .Matches(@"^[A-Z]{3}[0-9][A-Z0-9][0-9]{2}$").WithMessage("Placa inválida. Ex: ABC1D23");

        RuleFor(v => v.CurrentMileage)
        .GreaterThanOrEqualTo(0).WithMessage("A quilometragem atual deve ser maior ou igual a zero.");

        RuleFor(v => v.ToleranceKm)
            .GreaterThanOrEqualTo(0).WithMessage("A tolerância de km deve ser maior ou igual a zero.");

    }
}
