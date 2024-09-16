using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Validation
{
    public class RaValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(Object? value, ValidationContext validationContext)
        {
            if (value == null || !(value is string ra))
            {
                return new ValidationResult("O RA é obrigatório.");
            }

            if (!ra.StartsWith("RA"))
            {
                return new ValidationResult("O RA deve começar com 'RA'.");
            }

            string nRA = ra.Substring(2);
            if (nRA.Length != 6 || !nRA.All(char.IsDigit))
            {
                return new ValidationResult("RA inválido. Deve conter exatamente 6 dígitos numéricos após 'RA'.");
            }

            return ValidationResult.Success;
        }
    }
}
