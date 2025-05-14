using FluentValidation;
using Manutec.Application.Commands.WorkShopEntity;

namespace Manutec.Application.Validators.WorkShopValidate;
public class WorkShopValidator : AbstractValidator<InsertWorkShopCommand>
{
    public WorkShopValidator()
    {
        RuleFor(w => w.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O nome da oficina é obrigatório.")
            .MaximumLength(100).WithMessage("O nome da oficina deve ter no máximo 100 caracteres.");

        RuleFor(u => u.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("Formato de e-mail inválido.");

        RuleFor(u => u.Phone)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O telefone é obrigatório.")
            .Matches(@"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$").WithMessage("Número de telefone inválido.");
    }
}
