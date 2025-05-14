using FluentValidation;
using Manutec.Application.Commands.UserEntity;

namespace Manutec.Application.Validators.UserValidate;
public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidator()
    {
        RuleFor(u => u.UserName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O nome do usuário é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do usuário deve ter no máximo 100 caracteres.");

        RuleFor(u => u.PasswordHash)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");

        RuleFor(u => u.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("Formato de e-mail inválido.");

        RuleFor(u => u.Phone)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O telefone é obrigatório.")
            .Matches(@"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$").WithMessage("Número de telefone inválido.");

        RuleFor(u => u.Role)
            .IsInEnum().WithMessage("Opção de perfil inexistente.");
    }
}
