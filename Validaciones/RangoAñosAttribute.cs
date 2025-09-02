using System.ComponentModel.DataAnnotations;

namespace CalculadoraDePrestamos.Validaciones
{
    public class RangoAñosAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {


            var entero = (int)value!;


            if (entero >= 1 && entero <= 30)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("El plazo debe ser entre 1 y 30 Años ");


        }
    }
}
