using System.ComponentModel.DataAnnotations;

namespace AppMultiUsos.Validaciones
{
    public class RangoDivisas : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var convertido = (decimal)value!;

            //100,000,000,
            if (convertido > 10000000000)
            {
                return new ValidationResult("el monto debe ser mayor o igual a 1000");
            }

            return ValidationResult.Success;
        }
    }
}


