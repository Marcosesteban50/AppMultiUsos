using System.ComponentModel.DataAnnotations;
using CalculadoraDePrestamos.Validaciones;

namespace CalculadoraDePrestamos.Modelos.CalculadoraPrestamos
{
    public class SolicitudPrestamo
    {


        [Required(ErrorMessage = "El {0} es requerido")]
      
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        
        public int PlazoAnios { get; set; }

        [Required(ErrorMessage = "La tasa de interés es requerida")]
        
        public decimal TasaInteres { get; set; }
    }
}
