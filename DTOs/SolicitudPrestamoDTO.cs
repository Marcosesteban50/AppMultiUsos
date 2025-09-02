using System.ComponentModel.DataAnnotations;
using CalculadoraDePrestamos.Validaciones;

namespace CalculadoraDePrestamos.DTOs
{
    public class SolicitudPrestamoDTO
    {


        
        [Required(ErrorMessage = "El {0} es requerido")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [Range(1,30, ErrorMessage = "El monto mínimo es $1000")]
        public int PlazoAnios { get; set; }

        [Required(ErrorMessage = "La tasa de interés es requerida")]
        [TasaInteres]
        public double TasaInteres { get; set; }
    }
}
