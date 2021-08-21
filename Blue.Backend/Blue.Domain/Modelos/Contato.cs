using Blue.Domain.Modelos.Validacoes;
using FluentValidation.Results;
using System;

using System.Threading.Tasks;

namespace Blue.Domain.Modelos
{
    public partial class Contato :  Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool IsValiIdForCreation()
        {
            ValidationResult = new ContatoValidationForCreation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool IsValiIdForDelete()
        {
            ValidationResult = new ContatoValidationForDelete().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool IsValiIdForPatch()
        {
            ValidationResult = new ContatoValidationForForPatch().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
