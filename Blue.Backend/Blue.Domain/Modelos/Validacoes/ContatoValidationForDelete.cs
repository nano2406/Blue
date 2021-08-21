using FluentValidation;

namespace Blue.Domain.Modelos.Validacoes
{ 
    class ContatoValidationForDelete : AbstractValidator<Contato>
    {
        public ContatoValidationForDelete()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O contato precisa ser informado")
                .NotNull();
        }
    }
}
