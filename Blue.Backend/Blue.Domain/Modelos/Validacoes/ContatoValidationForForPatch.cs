using FluentValidation;

namespace Blue.Domain.Modelos.Validacoes
{ 
    class ContatoValidationForForPatch : AbstractValidator<Contato>
    {
        public ContatoValidationForForPatch()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome precisa ser fornecido")
                .NotNull()
                .Length(3, 200).WithMessage("O Campo precisa ter no mínimo 3 caracter e no máximo 200");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O Email precisa ser fornecido")
                .NotNull()
                .MaximumLength(200).WithMessage("O Email não pode ter mais de 200 caracter");

            RuleFor(c => c.Fone)
                .NotEmpty().WithMessage("O fone precisa ser fornecido")
                .NotNull()
                .MaximumLength(11).WithMessage("O fone não pode ter mais de 11 caracter");
        }
    }
}
