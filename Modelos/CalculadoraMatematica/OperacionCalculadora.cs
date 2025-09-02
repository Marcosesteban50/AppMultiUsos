using System.ComponentModel.DataAnnotations;

namespace CalculadoraDePrestamos.Modelos.CalculadoraMatematica
{
    public class OperacionCalculadora
    {


        [Required(ErrorMessage ="El campo {0} es requerido")]
        public decimal Numero1 { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string? Operacion { get; set; }  // "+", "-", "*", "/", "="
    }
}
