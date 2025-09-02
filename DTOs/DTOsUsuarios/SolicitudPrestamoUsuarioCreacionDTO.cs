using System.ComponentModel.DataAnnotations;
using CalculadoraDePrestamos.Validaciones;

namespace CalculadoraDePrestamos.DTOs.DTOsUsuarios
{
    public class SolicitudPrestamoUsuarioCreacionDTO
    {
        
        [Required(ErrorMessage = "El {0} es requerido")]
        [Rango]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [RangoAños]
        public int PlazoAnios { get; set; }

        [Required(ErrorMessage = "La tasa de interés es requerida")]
        [TasaInteres]
        public double TasaInteres { get; set; }

        public  DateTime FechaCreacionSolicitud { get; set; }  = DateTime.Now;
    }
}

