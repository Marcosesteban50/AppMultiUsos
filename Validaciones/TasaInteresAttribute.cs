using System.ComponentModel.DataAnnotations;

namespace CalculadoraDePrestamos.Validaciones
{
    public class TasaInteresAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var convertido = (double)value!;

            if (convertido >= 0.1 && convertido <= 30)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("La taza debe ser entre 0.1%  y 30% ");


        }
    }
}
