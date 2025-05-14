using FluentValidation;
using Manutec.Application.Commands.MaintenanceEntity;

namespace Manutec.Application.Validators.MaintenanceValidate;
public class UpdateMaintenanceValidator : AbstractValidator<InsertMaintenanceCommand>
{
    public UpdateMaintenanceValidator()
    {
        RuleFor(m => m.VehicleId)
            .GreaterThan(0).WithMessage("O id do veículo é obrigatório.");

        RuleFor(m => m.WorkShopId)
           .GreaterThan(0).WithMessage("O id da oficina é obrigatório.");

        RuleFor(m => m.Type)
            .IsInEnum().WithMessage("Tipo de manutenção inválido.");

        RuleFor(m => m.ScheduledDate)
           .Cascade(CascadeMode.Stop)
           .NotEmpty().WithMessage("A data agendada é obrigatória.")
           .GreaterThanOrEqualTo(DateTime.Today).WithMessage("A data agendada não pode ser no passado.");

        RuleFor(m => m.ScheduledMileage)
            .GreaterThanOrEqualTo(0).WithMessage("A quilometragem agendada deve ser maior ou igual a zero.");

        RuleFor(m => m.Cost)
            .GreaterThanOrEqualTo(0).WithMessage("O custo da manutenção deve ser maior ou igual a zero.");

        RuleFor(m => m.Description)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("A descrição é obrigatória.")
            .MaximumLength(255).WithMessage("A descrição deve ter no máximo 255 caracteres.");
    }
}
