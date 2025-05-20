using FluentValidation;
using Manutec.Application.Commands.MaintenanceEntity;

namespace Manutec.Application.Validators.MaintenanceValidate;
public class UpdateMaintenanceStatusCompletedCommandValidator : AbstractValidator<UpdateMaintenanceStatusCompletedCommand>
{
    public UpdateMaintenanceStatusCompletedCommandValidator()
    {
        RuleFor(c => c.Id)
            .GreaterThan(0).WithMessage("Id da manutenção é obrigatório.");

        RuleFor(c => c.WorkShopId)
            .GreaterThan(0).WithMessage("Id da oficina é obrigatório.");

        RuleFor(c => c.VehicleId)
            .GreaterThan(0).WithMessage("Id do veículo é obrigatório.");

        When(c => c.PerformedDate.HasValue || c.PerformedMileage.HasValue, () =>
        {
            RuleFor(c => c.PerformedDate)
                .NotNull().WithMessage("A data de realização é obrigatória.");

            RuleFor(c => c.PerformedMileage)
                .NotNull().WithMessage("A quilometragem de realização é obrigatória.")
                .GreaterThan(0).WithMessage("A quilometragem deve ser maior que zero.");
        });
    }
}
