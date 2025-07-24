using CrudSqlServerDapper.Entities;
using FluentValidation;

namespace CrudSqlServerDapper.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            // Validação do campo Nome
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Por favor, preencha o nome do cliente.")
                .MinimumLength(6).WithMessage("O nome do cliente deve ter pelo menos 6 caracteres.");

            // Validação do campo Email
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Por favor, preencha o e-mail do cliente.")
                .EmailAddress().WithMessage("Por favor, informe um e-mail válido.");

            // Validação do campo Data de Nascimento
            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser anterior a data atual.")
                .GreaterThan(DateTime.Now.AddYears(-120)).WithMessage("A data de nascimento deve ser posterior a 120 anos atrás.");
        }

    }
}
