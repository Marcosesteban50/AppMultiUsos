using System.ComponentModel.DataAnnotations;

namespace CalculadoraDePrestamos.DTOs
{
    public class OperacionCalculadoraDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public decimal Numero1 { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string? Operacion { get; set; }  // "+", "-", "*", "/", "="
    }
}
