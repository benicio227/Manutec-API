using FluentValidation;
using Manutec.Application.Commands.CustomerEntity;

namespace Manutec.Application.Validators.CustomerValidate;
public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().MaximumLength(100).WithMessage("O nome é obrigatório.");

        RuleFor(c => c.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("Formato de e-mail inválido.");

        RuleFor(c => c.Phone)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O telefone é obrigatório.")
            .Matches(@"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$").WithMessage("Número de telefone inválido.");

    }
}
