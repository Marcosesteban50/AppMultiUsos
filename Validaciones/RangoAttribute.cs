using System.ComponentModel.DataAnnotations;

namespace CalculadoraDePrestamos.Validaciones
{
    public class RangoAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var convertido = (decimal)value!;


            if (convertido < 1000)
            {
                return new ValidationResult("el monto debe ser mayor o igual a 1000");
            }

            return ValidationResult.Success;
        }
    }
}
